using Microsoft.EntityFrameworkCore;
using models;
// using Microsoft.Extensions.Configuration;

namespace Repository
{
	public class memeSaverContext : DbContext
	{
		public DbSet<Person> Persons { get; set; }
		public DbSet<Meme> Memes { get; set; }
		public DbSet<LikesJunction> LikesJunction { get; set; }

		public memeSaverContext(DbContextOptions<memeSaverContext> options) : base(options)
		{ }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// optionsBuilder.UseSqlServer(Configuration.GetConnectionString("memeDb"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LikesJunction>()
				.HasKey(c => new { c.PersonId, c.MemeId });
		}
	}
}