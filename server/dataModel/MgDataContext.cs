﻿using Microsoft.EntityFrameworkCore;

namespace dataModel
{
    public class MgDataContext : DbContext
    {
        public MgDataContext() { }
        public MgDataContext(DbContextOptions<MgDataContext> options)
            : base(options)
        {
        }

        public DbSet<Media> Media { get; set; }
        public DbSet<MediaArtist> MediaArtist { get; set; }
        public DbSet<MediaText> MediaText { get; set; }
        public DbSet<ParsedText> ParsedText { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=mg;user=root;password=p0k5PgOzmgkF");

                this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<MediaArtist>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaId).IsRequired();
            });

            modelBuilder.Entity<MediaText>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaId).IsRequired();
            });

            modelBuilder.Entity<ParsedText>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaTextId).IsRequired();
            });
        }
    }
}
