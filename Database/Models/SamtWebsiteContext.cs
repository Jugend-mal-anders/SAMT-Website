using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Database.Models;

public partial class SamtWebsiteContext : DbContext
{
    public SamtWebsiteContext()
    {
    }

    public SamtWebsiteContext(DbContextOptions<SamtWebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventsBringAndBuy> EventsBringAndBuys { get; set; }

    public virtual DbSet<EventsDateTime> EventsDateTimes { get; set; }

    public virtual DbSet<EventsExhibitorsApply> EventsExhibitorsApplies { get; set; }

    public virtual DbSet<EventsShowactApply> EventsShowactApplies { get; set; }

    public virtual DbSet<EventsWorkshopsApply> EventsWorkshopsApplies { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersSocialMediaCustom> UsersSocialMediaCustoms { get; set; }

    public virtual DbSet<UsersSocialMedium> UsersSocialMedia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql($"server=landofrails.net;port=3306;user=samt;password={File.ReadAllText("sensitive-data")};database=samt_website", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.18-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEnd).HasMaxLength(6);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.FkLocationId, "FK_Location_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.BringAndBuy)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.FkLocationId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_Location_ID");
            entity.Property(e => e.ImageLink).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Price).HasDefaultValueSql("'2'");

            entity.HasOne(d => d.FkLocation).WithMany(p => p.Events)
                .HasForeignKey(d => d.FkLocationId)
                .HasConstraintName("Events_ibfk_1");
        });

        modelBuilder.Entity<EventsBringAndBuy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Events_BringAndBuy");

            entity.HasIndex(e => e.FkEventId, "FK_Event_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.FkEventId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_Event_ID");
            entity.Property(e => e.Number).HasColumnType("int(11)");

            entity.HasOne(d => d.FkEvent).WithMany(p => p.EventsBringAndBuys)
                .HasForeignKey(d => d.FkEventId)
                .HasConstraintName("Events_BringAndBuy_ibfk_1");
        });

        modelBuilder.Entity<EventsDateTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Events_DateTime");

            entity.HasIndex(e => e.FkEventId, "FK_Event_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.EndTime).HasColumnType("time");
            entity.Property(e => e.FkEventId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_Event_ID");
            entity.Property(e => e.StartTime).HasColumnType("time");

            entity.HasOne(d => d.FkEvent).WithMany(p => p.EventsDateTimes)
                .HasForeignKey(d => d.FkEventId)
                .HasConstraintName("Events_DateTime_ibfk_1");
        });

        modelBuilder.Entity<EventsExhibitorsApply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Events_Exhibitors_Apply");

            entity.HasIndex(e => e.FkEventId, "FK_Event_ID");

            entity.HasIndex(e => e.FkUserId, "FK_User_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CoExhibitor).HasColumnType("text");
            entity.Property(e => e.FkEventId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_Event_ID");
            entity.Property(e => e.FkUserId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_User_ID");
            entity.Property(e => e.LessTable)
                .HasComment("1 = 'Sadly, that is not possible.'\r\n2 = 'Yes, could drop half a table (-0.5 table)'\r\n3 = 'Yes, could give up a whole table (-1 table)'\r\n4 = 'Yes, could give away 2 tables (-2 tables)'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Neighbors).HasColumnType("text");
            entity.Property(e => e.Questions).HasColumnType("text");
            entity.Property(e => e.ShortIntro)
                .HasComment("We try to pay attention to diversity and a different offering to the advantage of both exhibitors and visitors")
                .HasColumnType("text");
            entity.Property(e => e.Tables).HasColumnType("int(11)");

            entity.HasOne(d => d.FkEvent).WithMany(p => p.EventsExhibitorsApplies)
                .HasForeignKey(d => d.FkEventId)
                .HasConstraintName("Events_Exhibitors_Apply_ibfk_1");

            entity.HasOne(d => d.FkUser).WithMany(p => p.EventsExhibitorsApplies)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("Events_Exhibitors_Apply_ibfk_2");
        });

        modelBuilder.Entity<EventsShowactApply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Events_Showact_Apply");

            entity.HasIndex(e => e.FkEventId, "FK_Event_ID");

            entity.HasIndex(e => e.FkUserId, "FK_User_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Duration)
                .HasComment("1 = '20 minutes'\r\n2 = '30 minutes'\r\n3 = '45 minutes'\r\n4 = '1 hour'\r\n5 = 'More than 1 hour'")
                .HasColumnType("int(11)");
            entity.Property(e => e.EquipmentNeeds)
                .HasComment("special lightning, music, a whiteboard, pens etc.")
                .HasColumnType("text");
            entity.Property(e => e.FkEventId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_Event_ID");
            entity.Property(e => e.FkUserId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_User_ID");
            entity.Property(e => e.NumberActors)
                .HasComment("1 = '1'\r\n2 = '2-3'\r\n3 = '4-6'\r\n4 = '7-10'\r\n5 = '10+'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Questions).HasColumnType("text");
            entity.Property(e => e.ShortIntro).HasColumnType("text");
            entity.Property(e => e.Type)
                .HasComment("1 = 'Dance'\r\n2 = 'Cosplay, Showfights, Acting etc.'\r\n3 = 'Interactive program with the audience'\r\n4 = 'Singing, Music'\r\n5 = 'Educational, informative program'\r\n6 = 'none of the above'")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.FkEvent).WithMany(p => p.EventsShowactApplies)
                .HasForeignKey(d => d.FkEventId)
                .HasConstraintName("Events_Showact_Apply_ibfk_1");

            entity.HasOne(d => d.FkUser).WithMany(p => p.EventsShowactApplies)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("Events_Showact_Apply_ibfk_2");
        });

        modelBuilder.Entity<EventsWorkshopsApply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Events_Workshops_Apply");

            entity.HasIndex(e => e.FkEventId, "FK_Event_ID");

            entity.HasIndex(e => e.FkUserId, "FK_User_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Duration)
                .HasComment("1 = '30 minutes'\r\n2 = '1 hour'\r\n3 = '1 hour 30 minutes'\r\n4 = 'Up to 2 hours'\r\n5 = 'More than 2 hours'")
                .HasColumnType("int(11)");
            entity.Property(e => e.EquipmentNeeds)
                .HasComment("Materialien, Beamer, Whiteboard, Stifte, Fernseher, etc.")
                .HasColumnType("text");
            entity.Property(e => e.Fee)
                .HasComment("1 = 'Yes'\r\n2 = 'No'\r\n3 = 'I don''t know yet'")
                .HasColumnType("int(11)");
            entity.Property(e => e.FkEventId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_Event_ID");
            entity.Property(e => e.FkUserId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_User_ID");
            entity.Property(e => e.NumberMaxParticipants).HasColumnType("int(11)");
            entity.Property(e => e.Questions).HasColumnType("text");
            entity.Property(e => e.ShortDescription).HasColumnType("text");
            entity.Property(e => e.Type)
                .HasComment("1 = 'DIY workshop (e.g. handicrafts, synchro, game rounds, etc.)'\r\n2 = 'Round table discussion'\r\n3 = 'Lecture (Educational program)'")
                .HasColumnType("int(11)");
            entity.Property(e => e.TypeOther).HasColumnType("text");
            entity.Property(e => e.WorkshopName).HasColumnType("text");

            entity.HasOne(d => d.FkEvent).WithMany(p => p.EventsWorkshopsApplies)
                .HasForeignKey(d => d.FkEventId)
                .HasConstraintName("Events_Workshops_Apply_ibfk_1");

            entity.HasOne(d => d.FkUser).WithMany(p => p.EventsWorkshopsApplies)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("Events_Workshops_Apply_ibfk_2");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.City).HasColumnType("text");
            entity.Property(e => e.MapsLink).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Number).HasColumnType("int(11)");
            entity.Property(e => e.Plz)
                .HasColumnType("int(11)")
                .HasColumnName("PLZ");
            entity.Property(e => e.Street).HasColumnType("text");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ArtistName).HasColumnType("text");
            entity.Property(e => e.EMail)
                .HasColumnType("text")
                .HasColumnName("E-Mail");
            entity.Property(e => e.FirstName).HasColumnType("text");
            entity.Property(e => e.LastName).HasColumnType("text");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber).HasColumnType("text");
            entity.Property(e => e.SocialIntro)
                .HasComment("Intro text for our social media")
                .HasColumnType("text");
        });

        modelBuilder.Entity<UsersSocialMediaCustom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Users_SocialMedia_Custom");

            entity.HasIndex(e => e.FkUserSocialMediaId, "FK_User_SocialMedia_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.FkUserSocialMediaId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_User_SocialMedia_ID");
            entity.Property(e => e.Link).HasColumnType("text");
            entity.Property(e => e.Name).HasColumnType("text");

            entity.HasOne(d => d.FkUserSocialMedia).WithMany(p => p.UsersSocialMediaCustoms)
                .HasForeignKey(d => d.FkUserSocialMediaId)
                .HasConstraintName("Users_SocialMedia_Custom_ibfk_1");
        });

        modelBuilder.Entity<UsersSocialMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Users_SocialMedia");

            entity.HasIndex(e => e.FkUserId, "FK_User_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Etsy).HasColumnType("text");
            entity.Property(e => e.Facebook).HasColumnType("text");
            entity.Property(e => e.FkUserId)
                .HasColumnType("int(11)")
                .HasColumnName("FK_User_ID");
            entity.Property(e => e.Instagram).HasColumnType("text");
            entity.Property(e => e.Linktree).HasColumnType("text");
            entity.Property(e => e.Twitter).HasColumnType("text");
            entity.Property(e => e.YouTube).HasColumnType("text");

            entity.HasOne(d => d.FkUser).WithMany(p => p.UsersSocialMedia)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("Users_SocialMedia_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
