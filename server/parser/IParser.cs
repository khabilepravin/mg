using dataModel;
using System.Collections.Generic;

namespace mgparser
{
    public interface IParser
    {
        IEnumerable<ParsedText> Parse(MediaText mediaText);
    }
}
