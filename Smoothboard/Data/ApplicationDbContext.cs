using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smoothboard.Models;

namespace Smoothboard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Smoothboard.Models.Klant>? Klant { get; set; }
        public DbSet<Smoothboard.Models.Opdracht>? Opdracht { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship between Klant and Opdracht
            modelBuilder.Entity<Opdracht>()
                .HasOne(o => o.Klant)
                .WithMany(k => k.Opdrachten)
                .HasForeignKey(o => o.KlantId);
        }

        public DbSet<Smoothboard.Models.OpdrachtTest>? OpdrachtTest { get; set; }
    }
}