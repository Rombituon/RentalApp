using Microsoft.EntityFrameworkCore;
using RentalApp.Models;

namespace RentalApp.Data
{
    public class RentalDataContext : DbContext
    {
        public RentalDataContext(DbContextOptions options) : base(options)
        {
         
        }

        public DbSet<Renter> Renters { get; set; }
    }
}
