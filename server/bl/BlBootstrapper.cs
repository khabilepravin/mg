using Autofac;
using indexing;
using mgparser;

namespace bl
{
    public  static class BlBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            dataModel.DataBootstrapper.Bootstrap(containerBuilder);
            ParserBootstrapper.Bootstrap(containerBuilder);
            IndexingBootstrapper.Bootstrap(containerBuilder);
            containerBuilder.RegisterType<MediaManager>().As<IMediaManager>();
            containerBuilder.RegisterType<IndexManager>().As<IIndexManager>();
        }
    }
}
