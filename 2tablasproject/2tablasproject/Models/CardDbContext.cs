using _2tablasproject.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Models
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options)
        {

        }

        public CardDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=192.168.50.149; database=2tablasproject; user=root; password=password", ServerVersion.AutoDetect("server=192.168.50.149; database=2tablasproject; user=root; password=password"));
            }
        }
        public DbSet<PersonalDataClass> PersonalDataClasses { get; set; } = null!;
    }
}
