namespace DcmParserLib.Abstractions
{
    public interface IContentNodeFactory
    {
        ContentNode CreateContentNode(ParserContext parserContext);
    }
}