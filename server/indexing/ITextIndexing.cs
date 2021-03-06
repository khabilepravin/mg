﻿using dataModel;
using System.Collections.Generic;

namespace indexing
{
    public interface ITextIndexing
    {
        void AddUpdateLuceneIndex(IEnumerable<ParsedText> dataToIndex);
        IEnumerable<ParsedText> Search(string searchQuery, string searchField = null);
    }
}
