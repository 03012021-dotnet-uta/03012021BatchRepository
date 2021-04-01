using System;
using System.Collections.Generic;
using System.Linq;
using models;

namespace Repository
{
    //The job of this class is to ONLY deal with the Db and whatever 
    // specific logic is related to that.
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
            /**use the context to call the Db and query for the first user that
            matches the first and last name*/
            Person user1 = new Person()
            {
                Fname = "Jerry",
                Lname = "Walker"
            };
            user.Fname += user1.Fname;
            user.Lname += user1.Lname;
            return user;
        }

        /// <summary>
        /// Takes a username and returns true if the username is found in the Db.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method takes a string of the username and returns the Person object from the Db
        /// If no person is found, returns null.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Person GetPersonByUsername(string username)
        {
            Person foundPerson = _context.Persons.FirstOrDefault(p => p.UserName == username);
            return foundPerson;
        }

        public void SaveChanges()
        {
            // add addittional syeps before saving changes... based on changed needs.
            _context.SaveChanges();
        }

        public bool InsertMeme(Meme meme1)
        {
            var result = _context.Memes.Add(meme1);
            return true;
        }

        public ICollection<Meme> Memes()
        {
            ICollection<Meme> memes = _context.Memes.ToList();
            return memes;
        }


    }//end of class
}// end of namespace
