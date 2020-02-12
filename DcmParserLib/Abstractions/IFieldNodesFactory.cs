using System.Collections.Generic;

namespace DcmParserLib.Abstractions
{
    public interface IFieldNodesFactory
    {
        IEnumerable<FieldNode> CreateFieldNodes(ParserContext parserContext);
    }
}