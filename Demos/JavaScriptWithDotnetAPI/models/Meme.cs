using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace models
{
	public class Meme
	{
		[Key]
		public Guid MemeId { get; set; } = new Guid();
		public string MemeString { get; set; }
		public DateTime UploadDate { get; set; }
		public Guid Uploader { get; set; }
		public int Likes { get; set; }

		ICollection<Person> WhoLiked { get; set; }
	}
}