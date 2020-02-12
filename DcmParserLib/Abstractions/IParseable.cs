namespace DcmParserLib.Abstractions
{
    public interface IParseable
    {
        void Accept(INodeParser nodeParser);
    }
}