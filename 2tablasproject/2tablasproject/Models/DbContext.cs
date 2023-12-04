using Microsoft.EntityFrameworkCore;

namespace _2tablasproject.Models
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
        {

        }

        public CardDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost; database=2tablasproject; user=root; password=",
                                        ServerVersion.AutoDetect("server=localhost; database=2tablasproject; user=root; password="));
            }
        }

        public DbSet<PersonalDataClass> PersonalDataClasses { get; set; } = null!;
    }
}
