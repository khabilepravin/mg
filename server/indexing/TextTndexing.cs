using dataModel;
using dataModel.Repositories;
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
    public class TextIndexing : ITextIndexing
    {

        string _luceneDir;
        private IParsedTextRespository _parsedTextRespository;
        public TextIndexing(IParsedTextRespository parsedTextRespository)
        {
            _luceneDir = AppDomain.CurrentDomain.BaseDirectory + "luceneindex";
            _parsedTextRespository = parsedTextRespository;
        }

        private  FSDirectory _directoryTemp;
        private  FSDirectory _directory
        {
            get
            {
                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                return _directoryTemp;
            }
        }

        public  void AddUpdateLuceneIndex(IEnumerable<ParsedText> dataToParse, string titleId=null)
        {
            // init lucene
            var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // add data to lucene search index (replaces older entries if any)
                foreach (var sampleData in dataToParse) _addToLuceneIndex(sampleData, writer, titleId);

                // close handles
                analyzer.Close();
                writer.Dispose();
            }
        }

        private  void _addToLuceneIndex(ParsedText sampleData, IndexWriter writer, string titleId=null)
        {
            // remove older index entry
            //var searchQuery = new TermQuery(new Term("Id", sampleData.Id.ToString()));
            //writer.DeleteDocuments(searchQuery);

            // add new index entry
            var doc = new Document();

            // add lucene fields mapped to db fields
            doc.Add(new Field("Id", sampleData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("TitleId", titleId, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Text", sampleData.Text, Field.Store.NO, Field.Index.ANALYZED));


            // add entry to index
            writer.AddDocument(doc);
        }

        public  IEnumerable<ParsedText> Search(string searchQuery, string searchField = null, string titleId=null)
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
                        (Lucene.Net.Util.Version.LUCENE_30, new[] { "Id", "Text", "TitleId" }, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search(query, null, hits_limit, Sort.INDEXORDER).ScoreDocs;
                    var results = _mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
            }
        }

        private  Query parseQuery(string searchQuery, QueryParser parser)
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
        
        private  IEnumerable<ParsedText> _mapLuceneToDataList(IEnumerable<ScoreDoc> hits, IndexSearcher searcher)
        {   
            return hits.Select(hit => _mapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
        }

        private  ParsedText _mapLuceneDocumentToData(Document doc)
        {
            var parsedText = _parsedTextRespository.GetParsedText(doc.Get("Id")).Result;
            return new ParsedText
            {
                Id = doc.Get("Id"),
                Text = parsedText.Text
            };
        }
    }
}
