using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Purrrfect_Cats.Models;


namespace Purrrfect_Cats.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hashtag> Hashtags { get; set; }//DbSet instead of internal object
    }
}