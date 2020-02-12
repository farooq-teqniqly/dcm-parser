namespace DcmParserLib.Abstractions
{
    public abstract class FileNode : IParseable
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public abstract void Accept(INodeParser nodeParser);
    }
}