using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
	public class Person
	{
		[Key]
		public Guid PersonId { get; set; } = new Guid();
		public string Fname { get; set; }
		public string Lname { get; set; }

		ICollection<Meme> Memes { get; set; }// memes that I have uploaded

		ICollection<Meme> MemesILiked { get; set;}// this is the memes I have liked.
	}
}