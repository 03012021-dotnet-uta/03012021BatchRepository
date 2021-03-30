using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; } = Guid.NewGuid();
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string UserName { get; set; }//needed from user
        public byte[] PasswordHash { get; set; }//needed from user... but hashed behind the scenes
        public byte[] PasswordSalt { get; set; }// comes from the {} in the system
        public DateTime MemberSince { get; set; } = DateTime.Now;

        ICollection<Meme> Memes { get; set; }// memes that I have uploaded
        ICollection<Meme> MemesILiked { get; set; }// this is the memes I have liked.
    }
}