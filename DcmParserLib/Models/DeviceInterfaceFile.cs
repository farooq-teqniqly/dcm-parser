using System.Collections.Generic;

namespace DcmParserLib.Models
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
}