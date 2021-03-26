using System;

namespace models
{
	public class LikesJunction
	{
		//public int LikesJunctionId { get; set; }
		public Guid PersonId { get; set; }
		public Guid MemeId { get; set; }
	}
}