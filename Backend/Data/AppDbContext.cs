using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pant> PantedItems { get; set; }
        public DbSet<Pantelotteri> Pantelotterier { get; set; }
        public DbSet<PantelotteriLodd> LotteryTickets { get; set; }
        public DbSet<Pantemaskin> Pantemaskiner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User  Pant (One-to-Many)
            modelBuilder.Entity<Pant>()
                .HasOne(p => p.User)
                .WithMany(u => u.PantedItems)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Pant  Pantemaskin (One-to-Many)
            modelBuilder.Entity<Pant>()
                .HasOne(p => p.Pantemaskin)
                .WithMany(m => m.PantedItems)
                .HasForeignKey(p => p.PantemaskinId);

            // PantelotteriLodd  User (Many-to-One)
            modelBuilder.Entity<PantelotteriLodd>()
                .HasOne(l => l.User)
                .WithMany(u => u.LotteryTickets)
                .HasForeignKey(l => l.UserId);

            // PantelotteriLodd  Pant
            modelBuilder.Entity<PantelotteriLodd>()
                .HasOne(l => l.Pant)
                .WithMany(p => p.Lodd)
                .HasForeignKey(l => l.PantId);

            // PantelotteriLodd  Pantelotteri
            modelBuilder.Entity<PantelotteriLodd>()
                .HasOne(l => l.Lotteri)
                .WithMany(pl => pl.Tickets)
                .HasForeignKey(l => l.LotteriId);

            // PantelotteriLodd  Pantemaskin
            modelBuilder.Entity<PantelotteriLodd>()
                .HasOne(l => l.Pantemaskin)
                .WithMany(m => m.Lodd)
                .HasForeignKey(l => l.PantemaskinId);

            // Pantelotteri  Winner (Optional, No Cascade)
            modelBuilder.Entity<Pantelotteri>()
                .HasOne(p => p.Winner)
                .WithMany(u => u.WonLotteries)
                .HasForeignKey(p => p.WinnerUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
