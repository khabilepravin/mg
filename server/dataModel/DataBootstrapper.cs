using Autofac;
using dataModel.Repositories;

namespace dataModel
{
    public static class DataBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DbContextFactory>().As<IDbContextFactory>().SingleInstance();
            containerBuilder.RegisterType<MediaRepository>().As<IMediaRepository>().SingleInstance();
        }
    }
}
