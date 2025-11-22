using Microsoft.EntityFrameworkCore;
using Portfolio_Tracker_API.Models;

namespace Portfolio_Tracker_API.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Investments)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Investment>()
                .HasMany(i => i.Transactions)
                .WithOne(t => t.Investment)
                .HasForeignKey(t => t.InvestmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
