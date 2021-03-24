using System;
using models;
using Repository;

namespace BusinessLogic
{
    public class UserMethods
    {
        private readonly MemeSaverRepo repolayer;

        public UserMethods(MemeSaverRepo repolayer)
        {
            this.repolayer = repolayer;
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

            Person user1 = repolayer.Login(user);

            return user1;
        }
    }
}
