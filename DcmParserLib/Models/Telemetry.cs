namespace DcmParserLib.Models
{
    public class Telemetry
    {
        public Telemetry()
        {
            Schema = new Schema();
        }

        public string Type { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Comment { get; set; }
        public Schema Schema { get; set; }
    }
}