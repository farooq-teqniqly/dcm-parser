namespace DcmParserLib.Abstractions
{
    public abstract class ContentNode
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Comment { get; set; }
        public SchemaNode Schema { get; set; }
    }
}