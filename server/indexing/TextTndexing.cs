using dataModel;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System.Collections.Generic;

namespace indexing
{
    public class TextIndexing : ITextIndexing
    {
        private Analyzer analyzer = new WhitespaceAnalyzer(Lucene.Net.Util.LuceneVersion.LUCENE_48);
        private Directory luceneIndexDirectory;
        //        private IndexWriter writer;
        private DirectoryReader Reader;
        private string indexPath = @"c:\users\pravin.khabile\luceneindex";

        public TextIndexing()
        {
            InialiseLucene();
        }

        private void InialiseLucene()
        {
            if (System.IO.Directory.Exists(indexPath))
            {
                System.IO.Directory.Delete(indexPath, true);
            }

            luceneIndexDirectory = FSDirectory.Open(indexPath);



        }
       
        public bool IndexText(IEnumerable<ParsedText> dataToIndex)
        {
            IndexWriterConfig config = new IndexWriterConfig(Lucene.Net.Util.LuceneVersion.LUCENE_48, analyzer);

            using (var writer = new IndexWriter(luceneIndexDirectory, config))
            {
                foreach (var parsedText in dataToIndex)
                {
                    Document doc = new Document();
                    doc.Add(new StringField("LineNumber", parsedText.Id, Field.Store.YES));
                    doc.Add(new StringField("LineText", parsedText.Text, Field.Store.YES));

                    writer.AddDocument(doc.Fields);
                }

                Reader = writer.GetReader(true);
            }

            return true;
        }

        public IEnumerable<ParsedText> SearchText(string searchString)
        {
            IndexSearcher searcher = new IndexSearcher(Reader);
            QueryParser parser = new QueryParser(Lucene.Net.Util.LuceneVersion.LUCENE_48, "Text", analyzer);

            Query query = parser.Parse(searchString);
            Sort sort = new Sort(new SortField("Text", SortFieldType.STRING));
            var searchedDocs = searcher.Search(query, int.MaxValue, sort);
            List<ParsedText> results = new List<ParsedText>();
            ParsedText parsedText = null;
            

            for (int i = 0; i < searchedDocs.TotalHits; i++)
            {
                parsedText = new ParsedText();
                var doc = searchedDocs.ScoreDocs[i];// hitsFound.Doc(i);
                //parsedText.Id = int.Parse(doc. .Get("id"));
                //sampleDataFileRow.LineText = doc.Get("LineText");
                //float score = hitsFound.Score(i);
                //sampleDataFileRow.Score = score;
                //results.Add(sampleDataFileRow);
            }

            //return results.OrderByDescending(x => x.Score).ToList();
            return null;
        }
    }
}
