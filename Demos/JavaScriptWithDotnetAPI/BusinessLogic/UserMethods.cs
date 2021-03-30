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



    }// end of class
}// end of namespace
