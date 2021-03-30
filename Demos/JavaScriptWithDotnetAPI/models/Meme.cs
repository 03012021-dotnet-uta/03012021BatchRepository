using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Meme
    {
        [Key]
        public Guid MemeId { get; set; } = Guid.NewGuid();
        public string MemeString { get; set; }
        public DateTime UploadDate { get; set; }
        //public Guid Uploader { get; set; }// not needed bc teh PersonId and Person below will be that FK
        //public int Likes { get; set; }// not needed bc I can get the numebr from the length of the WhoLiked Collection below.

        ICollection<Person> WhoLiked { get; set; }//defines who has liked this meme many-to-many relationship

        public int PersonId { get; set; }// these together define the 1-many relationship
                                         //public Person Person { get; set; }// 
    }
}