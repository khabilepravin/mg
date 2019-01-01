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
            });

            modelBuilder.Entity<TextTag>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ParsedTextId).IsRequired();
                entity.Property(e => e.TagId).IsRequired();
            });

            modelBuilder.Entity<UserCollection>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<UserCollectionItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CollectionId).IsRequired();
                entity.Property(e => e.EntityId).IsRequired();
            });

            modelBuilder.Entity<ParsedTextArtist>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MediaArtistId).IsRequired();
                entity.Property(e => e.ParsedTextId).IsRequired();
            });
        }
    }
}
