using System;
using System.Collections.Generic;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=landofrails.net;port=3306;user=samt;password=hTLbtLaoOCP1thKy;database=samt_website", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.FkLocationId, "FK_Location_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FkLocationId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_Location_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.FkLocation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.FkLocationId)
                    .HasConstraintName("Events_ibfk_1");
            });

            modelBuilder.Entity<EventsGuest>(entity =>
            {
                entity.ToTable("Events_Guests");

                entity.HasIndex(e => new { e.FkEventId, e.FkGuestsId }, "FK_Event_ID");

                entity.HasIndex(e => e.FkGuestsId, "FK_Guests_ID");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.FkEventId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_Event_ID");

                entity.Property(e => e.FkGuestsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_Guests_ID");

                entity.HasOne(d => d.FkEvent)
                    .WithMany(p => p.EventsGuests)
                    .HasForeignKey(d => d.FkEventId)
                    .HasConstraintName("Events_Guests_ibfk_1");

                entity.HasOne(d => d.FkGuests)
                    .WithMany(p => p.EventsGuests)
                    .HasForeignKey(d => d.FkGuestsId)
                    .HasConstraintName("Events_Guests_ibfk_2");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ImageLink).HasColumnType("text");

                entity.Property(e => e.Instagram).HasColumnType("text");

                entity.Property(e => e.Linktree).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Twitter).HasColumnType("text");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Number).HasColumnType("int(11)");

                entity.Property(e => e.Plz)
                    .HasColumnType("int(11)")
                    .HasColumnName("PLZ");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
