using Microsoft.EntityFrameworkCore;

namespace RpsGame_NoDb
{
    public class DbContextClass : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Match> Matchs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CodeFirstRpsDemo;Trusted_Connection=True;");
        }
    }
}