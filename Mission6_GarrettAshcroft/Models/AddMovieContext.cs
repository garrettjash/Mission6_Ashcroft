using Microsoft.EntityFrameworkCore;

namespace Mission6_GarrettAshcroft.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base (options) 
        { }

        public DbSet<AddMovie> Movies { get; set; }
    }
}
