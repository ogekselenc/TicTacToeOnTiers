﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tictactoe.data;

#nullable disable

namespace tictactoe.data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250330001222_ImprovedGame")]
    partial class ImprovedGame
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardSize")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("OutcomeReason")
                        .HasColumnType("text");

                    b.Property<int>("OutcomeStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerOId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerXId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("WinningLineLength")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerOId");

                    b.HasIndex("PlayerXId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("tictactoe.data.Entities.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Column")
                        .HasColumnType("integer");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("Row")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("tictactoe.data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Game", b =>
                {
                    b.HasOne("tictactoe.data.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerOId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("tictactoe.data.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerXId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("tictactoe.data.Entities.Move", b =>
                {
                    b.HasOne("Game", null)
                        .WithMany("Moves")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Game", b =>
                {
                    b.Navigation("Moves");
                });
#pragma warning restore 612, 618
        }
    }
}
