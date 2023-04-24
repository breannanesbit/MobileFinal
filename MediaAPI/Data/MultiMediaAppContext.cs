using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace MediaAPI.Data;

public partial class MultiMediaAppContext : DbContext
{
    public MultiMediaAppContext()
    {
    }

    public MultiMediaAppContext(DbContextOptions<MultiMediaAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Media> Media { get; set; }

    public virtual DbSet<User> Users { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=multimediadatabase.postgres.database.azure.com; database=postgres; user id=breanna; password=Wearethechamps7");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "azure")
            .HasPostgresExtension("pg_catalog", "pgaadauth")
            .HasPostgresExtension("pg_cron");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("appointment_pkey");

            entity.ToTable("appointment", "mmapp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_user_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category", "mmapp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category1)
                .HasColumnType("character varying")
                .HasColumnName("category");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comments_pkey");

            entity.ToTable("comments", "mmapp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment1)
                .HasColumnType("character varying")
                .HasColumnName("comment");
            entity.Property(e => e.MediaId).HasColumnName("media_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            //entity.HasOne(d => d.Media).WithMany(p => p.Comments)
            //    .HasForeignKey(d => d.MediaId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("comments_media_id_fkey");

            //entity.HasOne(d => d.User).WithMany(p => p.Comments)
            //    .HasForeignKey(d => d.UserId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("comments_user_id_fkey");
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("media_pkey");

            entity.ToTable("media", "mmapp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.DateUpload)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_upload");
            entity.Property(e => e.FileName)
                .HasColumnType("character varying")
                .HasColumnName("file_name");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.MediaKey)
                .HasColumnType("character varying")
                .HasColumnName("media_key");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Media)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("media_category_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Media)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("media_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user", "mmapp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });
        modelBuilder.HasSequence("jobid_seq", "cron");
        modelBuilder.HasSequence("runid_seq", "cron");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
