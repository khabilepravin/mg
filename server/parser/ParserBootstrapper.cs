using Autofac;

namespace mgparser
{
    public static class ParserBootstrapper
    {
        public static void Bootstrap(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Parser>().As<IParser>();
        }
    }
}
