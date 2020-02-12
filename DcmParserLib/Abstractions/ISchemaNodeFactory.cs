using DcmParserLib.Parsers;

namespace DcmParserLib.Abstractions
{
    public interface ISchemaNodeFactory
    {
        SchemaNode CreateSchemaNode(ParserContext parserContext);
    }
}