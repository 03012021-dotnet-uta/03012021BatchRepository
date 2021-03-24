using Microsoft.EntityFrameworkCore;
using models;

namespace Repository
{
    public class memeSaverContext : DbContext
    {
        public memeSaverContext(DbContextOptions<memeSaverContext> options) : base()
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Meme> Memes { get; set; }
    }
}