using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Parsers
{
    public class DeviceInterfaceFileParser : IDcmJsonParser<DeviceInterfaceFile>
    {
        public DeviceInterfaceFile Parse(object obj)
        {
            var jo = (JObject) obj;
            var telemetryParser = new TelemetryJsonParser();
            var schemaParser = new SchemaJsonParser();

            var telemetries = new List<Telemetry>();

            foreach (var telemetryJson in jo["contents"])
            {
                var telemetry = telemetryParser.Parse(telemetryJson);
                var schema = schemaParser.Parse(telemetryJson);

                telemetry.Schema = schema;
                
                telemetries.Add(telemetry);
            }

            return new DeviceInterfaceFile
            {
                Telemetries = telemetries
            };
        }
    }
}
