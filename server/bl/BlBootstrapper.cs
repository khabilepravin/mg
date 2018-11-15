using Autofac;
using mgparser;

namespace bl
{
    public  static class BlBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            dataModel.DataBootstrapper.Bootstrap(containerBuilder);
            ParserBootstrapper.Bootstrap(containerBuilder);
            containerBuilder.RegisterType<MediaManager>().As<IMediaManager>();
        }
    }
}
