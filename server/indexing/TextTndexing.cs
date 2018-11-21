using dataModel;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace indexing
{
    public static class TextIndexing
    {
        //public static string _luceneDir =
        //    Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "lucene_index");
        //PATH FOR LOCAL TESTING
        //Path.Combine(@"C:\Personal\Projects\moviegrepRevival\moviregrepRevival\Source\humanInterface\ui", "lucene_index");
        static string _luceneDir = @"c:\users\pravin.khabile\luceneindexes-3";

        private static FSDirectory _directoryTemp;
        private static FSDirectory _directory
        {
            get
            {
                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                // var lockFilePath = Path.Combine(_luceneDir, "write.lock");
                //if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return _directoryTemp;
            }
        }

        public static void AddUpdateLuceneIndex(IEnumerable<ParsedText> sampleDatas)
        {
            // init lucene
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // add data to lucene search index (replaces older entries if any)
                foreach (var sampleData in sampleDatas) _addToLuceneIndex(sampleData, writer);

                // close handles
                analyzer.Close();
                writer.Dispose();
            }
        }

        private static void _addToLuceneIndex(ParsedText sampleData, IndexWriter writer)
        {
            // remove older index entry
            //var searchQuery = new TermQuery(new Term("Id", sampleData.Id.ToString()));
            //writer.DeleteDocuments(searchQuery);

            // add new index entry
            var doc = new Document();

            // add lucene fields mapped to db fields
            doc.Add(new Field("Id", sampleData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Text", sampleData.Text, Field.Store.NO, Field.Index.ANALYZED));


            // add entry to index
            writer.AddDocument(doc);
        }

        public static IEnumerable<ParsedText> Search(string searchQuery, string searchField = null)
        {
            if (string.IsNullOrWhiteSpace(searchQuery.Replace("*", string.Empty).Replace("?", string.Empty))) return new List<ParsedText>();

            // set up lucene searcher
            using (var searcher = new IndexSearcher(_directory, false))
            {
                var hits_limit = 1000;
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

                // search by single field
                if (!string.IsNullOrWhiteSpace(searchField))
                {
                    var sort = new Sort(new SortField[] {
                                            SortField.FIELD_SCORE,
                                            new SortField(searchField, SortField.STRING)
                                        });
                    TopFieldCollector topField = TopFieldCollector.Create(sort, hits_limit, true, true, true, true);


                    var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, searchField, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    //var hits = searcher.Search(query, hits_limit).ScoreDocs;
                    searcher.Search(query, topField);
                    var hits = topField.TopDocs().ScoreDocs;
                    var results = _mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
                // search by multiple fields (ordered by RELEVANCE)
                else
                {
                    var parser = new MultiFieldQueryParser
                        (Lucene.Net.Util.Version.LUCENE_30, new[] { "Id", "Text" }, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search(query, null, hits_limit, Sort.INDEXORDER).ScoreDocs;
                    var results = _mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
            }
        }

        private static Query parseQuery(string searchQuery, QueryParser parser)
        {
            Query query;
            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }
            return query;
        }

        //private static IEnumerable<ParsedText> mapSearchHitsToParsedText(IEnumerable<ScoreDoc> docs)
        //{

        //    return null;
        //}

        private static IEnumerable<ParsedText> _mapLuceneToDataList(IEnumerable<ScoreDoc> hits, IndexSearcher searcher)
        {
            // v 2.9.4: use 'hit.doc'
            // v 3.0.3: use 'hit.Doc'
            return hits.Select(hit => _mapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
        }
        private static ParsedText _mapLuceneDocumentToData(Document doc)
        {
            return new ParsedText
            {
                Id = Convert.ToString(doc.Get("Id")),
                Text = Convert.ToString(doc.Get("Text"))
            };
        }
    }
}
