namespace DcmParserLib.Models
{
    public class Telemetry
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Comment { get; set; }
        public Schema Schema { get; set; }
    }
}