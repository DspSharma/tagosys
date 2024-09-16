using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TagosysWeb.Data.Entities;

namespace TagosysWeb.Data.DBContext
{
    public partial class tagosyswebContext : DbContext
    {
        public tagosyswebContext()
        {
        }

        public tagosyswebContext(DbContextOptions<tagosyswebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Imagekitfile> Imagekitfiles { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Postdescription> Postdescriptions { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Systemsetting> Systemsettings { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=tagosysWebDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .HasColumnName("image");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Rating)
                    .HasMaxLength(5)
                    .HasColumnName("rating");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(100)
                    .HasColumnName("tittle");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .HasColumnName("message");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Subject)
                    .HasMaxLength(250)
                    .HasColumnName("subject");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Imagekitfile>(entity =>
            {
                entity.ToTable("imagekitfile");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.FileName)
                    .HasMaxLength(45)
                    .HasColumnName("fileName");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OriginalFileId)
                    .HasMaxLength(45)
                    .HasColumnName("originalFileId");

                entity.Property(e => e.ThumbnailFileId)
                    .HasMaxLength(45)
                    .HasColumnName("thumbnailFileId");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("pages");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(50)
                    .HasColumnName("tittle");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.PageId, "fk_pageId_posts");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .HasColumnName("image");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PageId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pageId");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(2000)
                    .HasColumnName("shortDescription");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(200)
                    .HasColumnName("tittle");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pageId_posts");
            });

            modelBuilder.Entity<Postdescription>(entity =>
            {
                entity.ToTable("postdescription");

                entity.HasIndex(e => e.PageId, "fk_pageId_postdescription");

                entity.HasIndex(e => e.PostId, "fk_postId_postdescription");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .HasColumnName("image");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PageId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pageId");

                entity.Property(e => e.PostId)
                    .HasColumnType("int(11)")
                    .HasColumnName("postId");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(250)
                    .HasColumnName("tittle");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Postdescriptions)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pageId_postdescription");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Postdescriptions)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_postId_postdescription");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .HasColumnName("image");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .HasColumnName("projectName");

                entity.Property(e => e.ProjectUrl)
                    .HasMaxLength(100)
                    .HasColumnName("projectUrl");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Systemsetting>(entity =>
            {
                entity.ToTable("systemsetting");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FacebookUrl)
                    .HasMaxLength(1000)
                    .HasColumnName("facebookUrl");

                entity.Property(e => e.InstagramUrl)
                    .HasMaxLength(1000)
                    .HasColumnName("instagramUrl");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Logo)
                    .HasMaxLength(100)
                    .HasColumnName("logo");

                entity.Property(e => e.MapUrl)
                    .HasMaxLength(1000)
                    .HasColumnName("mapUrl");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.OperationalOfficeAddress)
                    .HasMaxLength(250)
                    .HasColumnName("operationalOfficeAddress");

                entity.Property(e => e.RegisteredOfficeAddress)
                    .HasMaxLength(250)
                    .HasColumnName("registeredOfficeAddress");

                entity.Property(e => e.TwitterUrl)
                    .HasMaxLength(1000)
                    .HasColumnName("twitterUrl");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.YouTubeUrl)
                    .HasMaxLength(1000)
                    .HasColumnName("youTubeUrl");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .HasColumnName("designation");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .HasColumnName("image");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ProfessionField)
                    .HasMaxLength(100)
                    .HasColumnName("professionField");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.UserType)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
