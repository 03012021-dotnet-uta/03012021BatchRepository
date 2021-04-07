using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class StringPerson
    {
        [Key]
        public string PersonId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string UserName { get; set; }//needed from user
        public string PasswordHash { get; set; }//needed from user... but hashed behind the scenes
        //public string PasswordSalt { get; set; }// comes from the {} in the system
        public DateTime MemberSince { get; set; } = DateTime.Now;

        ICollection<Meme> Memes { get; set; } = new List<Meme>();// memes that I have uploaded
        ICollection<Meme> MemesILiked { get; set; } = new List<Meme>();// this is the memes I have liked.
    }
}