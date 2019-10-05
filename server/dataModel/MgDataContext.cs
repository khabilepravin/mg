using Microsoft.EntityFrameworkCore;

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
        public DbSet<TagMaster> TagMaster { get; set; }
        public DbSet<MediaTag> MediaTag { get; set; }
        public DbSet<TextTag> TextTag { get; set; }
        public DbSet<UserCollection> UserCollection { get; set; }
        public DbSet<UserCollectionItem> UserCollectionItem { get; set; }
        public DbSet<ParsedTextArtist> ParsedTextArtist { get; set; }
        public DbSet<UserFavorite> UserFavorite { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Comment this region-code for database migration and update
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=mg;user=root;password=p0k5PgOzmgkF");

                this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
            #endregion

            #region Uncomment this region-code for database migration and update
            //Note: Put the connection string of your db
            //optionsBuilder.UseMySql("server=localhost;database=mg;user=root;password=p0k5PgOzmgkF");
            #endregion
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
                entity.HasIndex(e => e.MediaId);
            });

            modelBuilder.Entity<MediaText>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaId).IsRequired();
                entity.HasIndex(e => e.MediaId);
            });

            modelBuilder.Entity<ParsedText>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaTextId).IsRequired();
                entity.HasIndex(e => e.MediaTextId);
            });

            modelBuilder.Entity<TagMaster>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<MediaTag>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaId).IsRequired();
                entity.Property(e => e.TagId).IsRequired();
                entity.HasIndex(e => e.MediaId);
                entity.HasIndex(e => e.TagId);
            });

            modelBuilder.Entity<TextTag>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ParsedTextId).IsRequired();
                entity.Property(e => e.TagId).IsRequired();
                entity.HasIndex(e => e.ParsedTextId);
                entity.HasIndex(e => e.TagId);
            });

            modelBuilder.Entity<UserCollection>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<UserCollectionItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CollectionId).IsRequired();
                entity.Property(e => e.EntityId).IsRequired();
                entity.HasIndex(e => e.CollectionId);
                entity.HasIndex(e => e.EntityId);
            });

            modelBuilder.Entity<ParsedTextArtist>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaArtistId).IsRequired();
                entity.Property(e => e.ParsedTextId).IsRequired();
                entity.HasIndex(e => e.MediaArtistId);
                entity.HasIndex(e => e.ParsedTextId);
            });

            modelBuilder.Entity<UserFavorite>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ParsedTextId).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.HasIndex(e => e.ParsedTextId);
                entity.HasIndex(e => e.UserId);
            });
        }
    }
}
