using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Takes a username and returns true if the username is found in the Db.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> UserExistsAsync(string userName)
        {
            //default is NULL
            if (await _context.Persons.Where(p => p.UserName == userName).FirstOrDefaultAsync() != null)
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
        public async Task<Person> RegisterAsync(Person newPerson)
        {
            var newPerson1 = _context.Persons.AddAsync(newPerson);// addd the new person to the Db
            await _context.SaveChangesAsync();// save the change.
            return await _context.Persons.FirstOrDefaultAsync(p => p.PersonId == newPerson.PersonId);// default is null
        }

        /// <summary>
        /// This method takes a string of the username and returns the Person object from the Db
        /// If no person is found, returns null.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<Person> GetPersonByUsernameAsync(string username)
        {
            Person foundPerson = await _context.Persons.FirstOrDefaultAsync(p => p.UserName == username);
            return foundPerson;
        }

        public async Task SaveChangesAsync()
        {
            // add addittional syeps before saving changes... based on changed needs.
            await _context.SaveChangesAsync();
        }

        public async Task<bool> InsertMemeAsync(Meme meme1)
        {
            var result = await _context.Memes.AddAsync(meme1);
            return true;
        }

        /// <summary>
        /// This method gets all memes and returns them asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Meme>> MemesAsync()
        {
            ICollection<Meme> memes = await _context.Memes.ToListAsync();
            return memes;
        }

        /// <summary>
        /// this method gets all the people in the persons table asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Person>> GetAllPeopleAsync()
        {
            ICollection<Person> people = await _context.Persons.ToListAsync();
            return people;
        }

        public async Task<Person> GetPersonByIdAsync(Guid guid)
        {
            Person p = await _context.Persons.FirstOrDefaultAsync(p => p.PersonId == guid);
            return p;
        }
    }//end of class
}// end of namespace
