using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SAMT_Website.models
{
    public partial class samt_websiteContext : DbContext
    {
        public samt_websiteContext()
        {
        }

        public samt_websiteContext(DbContextOptions<samt_websiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventsGuest> EventsGuests { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Text> Texts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql($"server=landofrails.net;port=3306;user=samt;password={File.ReadAllText("sensitive-data")};database=samt_website", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.LocationId, "LocationID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("LocationID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("Events_ibfk_1");
            });

            modelBuilder.Entity<EventsGuest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Events_Guests");

                entity.HasIndex(e => e.EventId, "EventID");

                entity.HasIndex(e => e.GuestId, "GuestID");

                entity.Property(e => e.EventId)
                    .HasColumnType("int(11)")
                    .HasColumnName("EventID");

                entity.Property(e => e.GuestId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GuestID");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("Events_Guests_ibfk_2");

                entity.HasOne(d => d.Guest)
                    .WithMany()
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("Events_Guests_ibfk_1");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.EMail)
                    .HasColumnType("text")
                    .HasColumnName("E-Mail");

                entity.Property(e => e.Facebook).HasColumnType("text");

                entity.Property(e => e.Instagram).HasColumnType("text");

                entity.Property(e => e.Linktree).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.City).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Street).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Text>(entity =>
            {
                entity.ToTable("Text");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .HasColumnName("ID");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
