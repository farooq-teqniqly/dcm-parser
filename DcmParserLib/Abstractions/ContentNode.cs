namespace DcmParserLib.Abstractions
{
    public abstract class ContentNode : IParseable
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public string Comment { get; set; }
        public abstract void Accept(INodeParser nodeParser);
    }
}