using Microsoft.EntityFrameworkCore;

namespace Mission06_Yates.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {
        }
        public DbSet<MovieForm> MovieForm { get; set; }
    }
}
