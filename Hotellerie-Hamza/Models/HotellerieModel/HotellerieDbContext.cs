using Microsoft.EntityFrameworkCore;

namespace Hotellerie_Hamza.Models.HotellerieModel
{
    public class HotellerieDbContext : DbContext
    {
        public HotellerieDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public DbSet<Appreciation> Appreciations { get; set; }  // Add this line

    }
}
