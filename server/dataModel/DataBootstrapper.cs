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
            containerBuilder.RegisterType<MediaTextRepository>().As<IMediaTextRespository>().SingleInstance();
            containerBuilder.RegisterType<ParsedTextRespository>().As<IParsedTextRespository>().SingleInstance();
            containerBuilder.RegisterType<MediaArtistRepository>().As<IMediaArtistRepository>().SingleInstance();
        }
    }
}
