using System;
using models;

namespace Repository
{
    public class MemeSaverRepo
    {
        private readonly memeSaverContext context;
        public MemeSaverRepo(memeSaverContext context)
        {
            this.context = context;
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
    }
}
