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
            containerBuilder.RegisterType<Search>().As<ISearch>();
            containerBuilder.RegisterType<TextManager>().As<ITextManager>();
            containerBuilder.RegisterType<MediaArtistManager>().As<IMediaArtistManager>();
            containerBuilder.RegisterType<TagManager>().As<ITagManager>();
            containerBuilder.RegisterType<TextTagManager>().As<ITextTagManager>();
            containerBuilder.RegisterType<UserCollectionManager>().As<IUserCollectionManager>();
            containerBuilder.RegisterType<ParsedTextArtistManager>().As<IParsedTextArtistManager>();
        }
    }
}
