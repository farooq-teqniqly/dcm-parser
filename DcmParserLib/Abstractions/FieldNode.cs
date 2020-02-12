namespace DcmParserLib.Abstractions
{
    public class FieldNode
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string DisplayUnit { get; set; }
        public SchemaNode Schema { get; set; }
    }
}