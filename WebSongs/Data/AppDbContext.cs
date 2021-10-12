using Microsoft.EntityFrameworkCore;

namespace WebSongs.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<WebSongs.Models.Song> Song { get; set; }
    }
}
