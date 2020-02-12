using System.Collections.Generic;
using DcmParserLib.Parsers;

namespace DcmParserLib.Abstractions
{
    public interface IFieldNodesFactory
    {
        IEnumerable<FieldNode> CreateFieldNodes(ParserContext parserContext);
    }
}