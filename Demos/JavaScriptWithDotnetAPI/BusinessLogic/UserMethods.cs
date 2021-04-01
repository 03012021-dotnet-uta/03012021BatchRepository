using System;
using System.Collections.Generic;
using System.IO;
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
        /// This method takes an int and returns four times the int.
        /// </summary>
        /// <param name="x"></param>
        /// <returns type="int"></returns>
        public int QuadrupleTheInt(int x)
        {
            int y = 0;
            y += x;
            x += y;
            x *= 2;
            return x;

            //return x * 4;
        }

        /// <summary>
        /// This method takes a user and returns a verified user, if it exists.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Person Login(Person user)
        {
            //call a method on the repository class that will query the Db
            // and return the verified person, if he exists.
            // otherwise return a Person with empty strings.
            user.Fname += user.Lname;
            user.Lname += user.Fname;

            Person user1 = _repolayer.Login(user);

            return user1;
        }

        /// <summary>
        /// This method takes a RawPerson representing a new users data.
        /// It returns the Person instance created in the database if the creation was successfull.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="rawPerson"></param>
        /// <returns></returns>
        public Person Register(RawPerson rawPerson)
        {
            if (_repolayer.UserExists(rawPerson.Username) == true)
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
                Person registeredPerson = _repolayer.Register(newPerson);//call a method on the repo layer to save the new person to the DB.
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
        public Person Login(string username, string password)
        {
            if (_repolayer.UserExists(username) == false)
            {
                return null;
            }
            else
            {
                //get the matching user with this Username
                Person foundPerson = _repolayer.GetPersonByUsername(username);

                // hash the provided password with the key from the found user
                byte[] hash = mapper.HashTheUsername(password, foundPerson.PasswordSalt);

                // compare the 2 hashes with a external method
                // if the 2 hashes match return the found user.
                if (CompareTwoHashes(foundPerson.PasswordHash, hash))
                {
                    return foundPerson;
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
        public bool Editperson(EditPerson editPerson)
        {
            //get the person by personId 
            Person dbPerson = _repolayer.GetPersonByUsername(editPerson.Username);

            if (dbPerson == null)
            {
                return false;
            }

            // compare Db personhash with received hash to verify it's the same GetPersonByUsername
            if (!CompareTwoHashes(dbPerson.PasswordHash, editPerson.PasswordHash)) return false;// when your body is just one line, you can disregard using the {}

            // hash the new password (if not null) and save it to the DbPerson
            if (editPerson.NewPassword != "")
            {
                byte[] hash = mapper.HashTheUsername(editPerson.NewPassword, dbPerson.PasswordSalt);
                dbPerson.PasswordHash = hash;
            }

            // save all new data to the Person.
            // this variable is a reference to the entity in the context in the repo layer
            dbPerson.Fname = editPerson.Fname;
            dbPerson.Lname = editPerson.Lname;
            dbPerson.UserName = editPerson.NewUsername;

            //save changed person to the Db.
            _repolayer.SaveChanges();
            return true;

        }

        /// <summary>
        /// This method accepts a personID and a iformfile image.
        /// It adds the new meme to the database and returns true if the addition was successful.
        /// Otherwise returns false.
        /// /// </summary>
        /// <returns></returns>
        public bool AddMeme(Guid personId, IFormFile meme)
        {
            // create a new Meme instance
            Meme meme1 = new Meme();
            byte[] memeBytes = mapper.ConvertMemeIformfileToByteArray(meme);

            //now pupulate the Meme instance 
            meme1.MemeByteArray = memeBytes;
            meme1.PersonId = personId;

            // call the context method to insert the new meme
            _repolayer.InsertMeme(meme1);
            _repolayer.SaveChanges();
            // this section is for convertying from a byte array to a string


            return true;
        }

        public ICollection<MemeDTO> Memes()
        {
            // get all the memes from the DB.
            ICollection<Meme> memes = _repolayer.Memes();
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
            }
            return memeDTOs;
        }
    }// end of class
}// end of namespace
