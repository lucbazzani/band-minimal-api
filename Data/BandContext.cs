using Band.Models;
using Microsoft.EntityFrameworkCore;

namespace Band.Data
{
    public class BandContext : DbContext
    {
        //In-memory representation of the Band table
        public DbSet<BandModel> Bands { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=band.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
