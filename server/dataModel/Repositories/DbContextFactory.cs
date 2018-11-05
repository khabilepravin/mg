using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dataModel.Repositories
{
    public class DbContextFactory : IDbContextFactory
    {
        private IConfiguration _configuration;
        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MgDataContext Create()
        {
            var options = new DbContextOptionsBuilder<MgDataContext>()
                .UseMySql(_configuration.GetConnectionString("DefaultConnection"))
                .Options;

            var context = new MgDataContext(options);

            return context;
        }

        public MgDataContext CreateNoTracking()
        {
            var context = Create();

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return context;
        }
    }
}
