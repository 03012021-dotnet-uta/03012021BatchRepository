using System;
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


    }// end of class
}// end of namespace
