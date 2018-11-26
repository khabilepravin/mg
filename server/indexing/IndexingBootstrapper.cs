using Autofac;

namespace indexing
{
    public static class IndexingBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TextIndexing>().As<ITextIndexing>().SingleInstance();
            
        }
    }
}
