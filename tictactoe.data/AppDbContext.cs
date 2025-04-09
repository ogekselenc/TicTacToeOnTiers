using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tictactoe.data.Entities;

namespace tictactoe.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tictactoeontiers;Username=ognjen;Password=ekselencija84.");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne<Player>()
                .WithMany()
                .HasForeignKey(g => g.PlayerXId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne<Player>()
                .WithMany()
                .HasForeignKey(g => g.PlayerOId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}