using System;
using System.Linq;
using models;

namespace Repository
{
    public class MemeSaverRepo
    {
        private readonly memeSaverContext _context;
        public MemeSaverRepo() { }// create this so that you can test this class without having to also create a context and repo.
        public MemeSaverRepo(memeSaverContext context)
        {
            this._context = context;
        }

        public Person Login(Person user)
        {
            /**use the context to call the Db 
            and query for the first usr that matches 
            the first and last name*/
            //Person user = context.Person.FirstOrDefault(p => p.Fname == user.Fname && p.Lname == user.Lname);
            Person user1 = new Person()
            {
                Fname = "Jerry",
                Lname = "Walker"
            };

            user.Fname += user1.Fname;
            user.Lname += user1.Lname;

            return user;

        }

        public bool UserExists(string userName)
        {
            //default is NULL
            if (_context.Persons.Where(p => p.UserName == userName).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method adds the verified new user to the Db and returns the Person object from the Db
        /// </summary>
        /// <param name="newPerson"></param>
        /// <returns></returns>
        public Person Register(Person newPerson)
        {
            var newPerson1 = _context.Persons.Add(newPerson);// addd the new person to the Db
            _context.SaveChanges();// save the change.
            return _context.Persons.FirstOrDefault(p => p.PersonId == newPerson.PersonId);// default is null
        }


    }//end of class
}// end of namespace
