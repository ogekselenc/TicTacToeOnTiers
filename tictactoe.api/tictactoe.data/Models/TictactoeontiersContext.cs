using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tictactoe.api.tictactoe.data.Models;

public partial class TictactoeontiersContext : DbContext
{
    public TictactoeontiersContext()
    {
    }

    public TictactoeontiersContext(DbContextOptions<TictactoeontiersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tictactoeontiers;Username=ognjen;Password=ekselencija84.");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasIndex(e => e.PlayerOid, "IX_Games_PlayerOId");

            entity.HasIndex(e => e.PlayerXid, "IX_Games_PlayerXId");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.OutcomeStatus).HasDefaultValue(0);
            entity.Property(e => e.PlayerOid)
                .HasDefaultValue(0)
                .HasColumnName("PlayerOId");
            entity.Property(e => e.PlayerXid)
                .HasDefaultValue(0)
                .HasColumnName("PlayerXId");
            entity.Property(e => e.WinningLineLength).HasDefaultValue(0);

            entity.HasOne(d => d.PlayerO).WithMany(p => p.GamePlayerOs)
                .HasForeignKey(d => d.PlayerOid)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.PlayerX).WithMany(p => p.GamePlayerXes)
                .HasForeignKey(d => d.PlayerXid)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Move>(entity =>
        {
            entity.HasIndex(e => e.GameId, "IX_Moves_GameId");

            entity.HasOne(d => d.Game).WithMany(p => p.Moves).HasForeignKey(d => d.GameId);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
