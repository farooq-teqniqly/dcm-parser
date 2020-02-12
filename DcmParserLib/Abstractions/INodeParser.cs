namespace DcmParserLib.Abstractions
{
    public interface INodeParser
    {
        void Parse(IParseable parseable);
    }
}