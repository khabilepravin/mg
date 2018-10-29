using dataModel;
using System.Collections.Generic;

namespace mgparser
{
    interface IParser
    {
        IEnumerable<ParsedText> Parse(MediaText mediaText);
    }
}
