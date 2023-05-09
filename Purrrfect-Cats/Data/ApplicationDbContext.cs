using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Purrrfect_Cats.Models;


namespace Purrrfect_Cats.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Hashtag>? Hashtags { get; set; }
        public DbSet<FavoriteCatsModel>? FavoriteCats { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set up your connection for many to many (skills to jobs)
            modelBuilder.Entity<FavoriteCatsModel>()
            .HasMany(p => p.Hashtags)
            .WithMany(b => b.FavoriteCats).UsingEntity(a => a.ToTable("CatTags"));

            base.OnModelCreating(modelBuilder);
        }
    }
}