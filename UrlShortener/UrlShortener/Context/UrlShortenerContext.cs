using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Context
{
    public class UrlShortenerContext
        : DbContext
    {
        public UrlShortenerContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<History> History { get; set; }
    }
}
