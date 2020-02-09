using System.Collections.Generic;

namespace DcmParserLib
{
    public class DeviceInterfaceFile
    {
        public DeviceInterfaceFile()
        {
            Telemetries = new List<Telemetry>();
        }

        public FileId FileId { get; set; }
        public List<Telemetry> Telemetries { get; set; }
    }

    public class FileId
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
    }

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

    public class Field
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DisplayUnit { get; set; }
        public string Schema { get; set; }
    }

    public class Schema
    {
        public Schema()
        {
            Fields = new List<Field>();
        }

        public string Type { get; set; }
        public List<Field> Fields { get; set; }
    }
}