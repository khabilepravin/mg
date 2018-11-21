using dataModel;
using indexing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test
{
    public class IndexingTests
    {
        [Fact]
        public void TestIndexing()
        {
            //TextIndexing indexing = new TextIndexing();

            List<ParsedText> itemsToIndex = new List<ParsedText>();

            itemsToIndex.Add(new ParsedText { Text = "Sometimes nothin can be areal cool hand", Id = "10001" });
            itemsToIndex.Add(new ParsedText { Text = "Not on the rug man", Id = "10002" });
            itemsToIndex.Add(new ParsedText { Text = "I will make him an offer he can't refuse", Id = "10003" });
            //TextIndexing.IndexText(itemsToIndex);
            TextIndexing.AddUpdateLuceneIndex(itemsToIndex);
            //IndexMiner.Search("rug");
        }

        [Fact]
        public void SearchTest()
        {
            TextIndexing.Search("cool");
        }
       
    }
}
