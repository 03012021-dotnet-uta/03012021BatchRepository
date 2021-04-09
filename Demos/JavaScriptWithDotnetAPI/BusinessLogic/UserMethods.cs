using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using models;
using Repository;

namespace BusinessLogic
{
    public class UserMethods
    {
        private readonly MemeSaverRepo _repolayer;
        private readonly Mapper mapper = new Mapper();

        public UserMethods() { }// create a parameterless constructor so that I can create this class in the testing suite.
        public UserMethods(MemeSaverRepo repolayer)
        {
            this._repolayer = repolayer;
        }

        /// <summary>
        /// This method takes a RawPerson representing a new users data.
        /// It returns the Person instance created in the database if the creation was successfull.
        /// /// Otherwise returns false.
        /// </summary>
        /// <param name="rawPerson"></param>
        /// <returns></returns>
        public async Task<Person> RegisterAsync(RawPerson rawPerson)
        {
            if (await _repolayer.UserExistsAsync(rawPerson.Username) == true)
            {
                return null;
            }
            else
            {
                //convert this rawperson to a Person
                // send in the submitted password and get back a Person obj with the hashed password and key for it.
                Person newPerson = mapper.GetANewPersonWithHashedPassword(rawPerson.Password);

                //transfer in the supplied data
                newPerson.Fname = rawPerson.Fname;
                newPerson.Lname = rawPerson.Lname;
                newPerson.UserName = rawPerson.Username;
                Person registeredPerson = await _repolayer.RegisterAsync(newPerson);//call a method on the repo layer to save the new person to the DB.
                return registeredPerson;
            }
        }

        /// <summary>
        /// this method accepts two strings representing a username and password a user inputted.
        /// It returns the Person instance from the database if that Person is found.
        /// Otherwise, rturns false.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<StringPersonDTO> LoginAsync(string username, string password)
        {
            if (await _repolayer.UserExistsAsync(username) == false)
            {
                return null;
            }
            else
            {
                //get the matching user with this Username
                Person foundPerson = await _repolayer.GetPersonByUsernameAsync(username);

                // hash the provided password with the key from the found user
                byte[] hash = mapper.HashThePassword(password, foundPerson.PasswordSalt);

                // compare the 2 hashes with a external method
                // if the 2 hashes match return the found user.
                if (CompareTwoHashes(foundPerson.PasswordHash, hash))
                {
                    //convert found person to a StringPerson
                    StringPersonDTO stringPerson = mapper.ConvertPersonToStringPerson(foundPerson);
                    return stringPerson;
                }
                else return null;
            }
        }

        /// <summary>
        /// This method accepts two byte[] annd compares their respective elements.
        /// It returns true if the byte[] are identical. False if not.
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        private bool CompareTwoHashes(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            //compare the hash of the inputted password and the found user
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                } // Unauthorized("Invalid Password");
            }
            return true;
        }

        /// <summary>
        /// This method accepts an EditPerson instance which represents the changes to be made
        /// to a Person in stance int he Db. It returns true if the changes are successfully made.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="editPerson"></param>
        /// <returns></returns>
        public async Task<bool> EditpersonAsync(EditPerson editPerson)
        {
            //get the person by personId 
            Person dbPerson = await _repolayer.GetPersonByUsernameAsync(editPerson.Username);

            if (dbPerson == null)
            {
                return false;
            }

            // compare Db personhash with received hash to verify it's the same GetPersonByUsername
            if (!CompareTwoHashes(dbPerson.PasswordHash, Convert.FromBase64String(editPerson.PasswordHash))) return false;// when your body is just one line, you can disregard using the {}

            // hash the new password (if not null) and save it to the DbPerson
            if (editPerson.NewPassword != "")
            {
                byte[] hash = mapper.HashThePassword(editPerson.NewPassword, dbPerson.PasswordSalt);
                dbPerson.PasswordHash = hash;
            }

            // save all new data to the Person.
            // this variable is a reference to the entity in the context in the repo layer
            dbPerson.Fname = editPerson.Fname;
            dbPerson.Lname = editPerson.Lname;
            dbPerson.UserName = editPerson.NewUsername;

            //save changed person to the Db.
            await _repolayer.SaveChangesAsync();
            return true;

        }

        /// <summary>
        /// This method accepts a personID and a iformfile image.
        /// It adds the new meme to the database and returns true if the addition was successful.
        /// Otherwise returns false.
        /// /// </summary>
        /// <returns></returns>
        public async Task<bool> AddMemeAsync(Guid personId, IFormFile meme)
        {
            // create a new Meme instance
            Meme meme1 = new Meme();
            byte[] memeBytes = await mapper.ConvertMemeIformfileToByteArrayAsync(meme);

            //now pupulate the Meme instance 
            meme1.MemeByteArray = memeBytes;
            meme1.PersonId = personId;

            // call the context method to insert the new meme
            await _repolayer.InsertMemeAsync(meme1);
            await _repolayer.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<MemeDTO>> MemesAsync()
        {
            // get all the memes from the DB.
            ICollection<Meme> memes = await _repolayer.MemesAsync();
            ICollection<MemeDTO> memeDTOs = new List<MemeDTO>();

            // convert all memes to MemeDTOs
            foreach (Meme m in memes)
            {
                //create a new MemeDTO
                MemeDTO memedto = new MemeDTO();

                //copy all values into the MemeDTOs
                memedto.MemeId = m.MemeId;
                memedto.PersonId = m.PersonId;
                memedto.UploadDate = m.UploadDate;

                //call method to conver the byte[] to a string
                var imageString = mapper.ConvertByteArrayToImageString(m.MemeByteArray);
                memedto.MemeString = imageString;
                memeDTOs.Add(memedto);
            }
            return memeDTOs;
        }

        public async Task<List<StringPersonDTO>> GetAllPeopleAsync()
        {
            ICollection<Person> people = await _repolayer.GetAllPeopleAsync();
            List<StringPersonDTO> stringPeople = new List<StringPersonDTO>();
            //convert all these Persons to StringPerson
            foreach (var foundPerson in people)
            {
                StringPersonDTO p = mapper.ConvertPersonToStringPerson(foundPerson);
                stringPeople.Add(p);
            }
            return stringPeople;
        }

        public async Task<StringPersonDTO> GetPersonByIdAsync(string personId)
        {
            //convert the string to Guid
            Guid guid = Guid.Parse(personId);
            //call repo method to get the person by the #if true
            Person p = await _repolayer.GetPersonByIdAsync(guid);
            StringPersonDTO sp = mapper.ConvertPersonToStringPerson(p);
            return sp;
        }

        public async Task<MemeDTO> GetMemeByIdAsync(string memeId)
        {
            //convert the string to Guid
            Guid guid = Guid.Parse(memeId);
            //call repo method to get the person by the #if true
            Meme m = await _repolayer.GetMemeByIdAsync(guid);
            MemeDTO memeDto = mapper.ConvertMemeToMemeDto(m);
            return memeDto;
        }

        public async Task<List<MemeDTO>> GetAllMemesAsync()
        {
            ICollection<Meme> memes = await _repolayer.GetAllMemesAsync();
            List<MemeDTO> memeDtos = new List<MemeDTO>();
            //convert all these Persons to StringPerson
            foreach (Meme m in memes)
            {
                MemeDTO mdto = mapper.ConvertMemeToMemeDto(m);
                memeDtos.Add(mdto);
            }
            return memeDtos;
        }

    }// end of class
}// end of namespace
