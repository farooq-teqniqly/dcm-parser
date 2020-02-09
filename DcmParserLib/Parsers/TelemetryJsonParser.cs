using System;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Parsers
{
    public class TelemetryJsonParser : IDcmJsonParser<Telemetry>
    {
        public Telemetry Parse(object obj)
        {
            var jo = (JObject) obj;
            var telemetry = new Telemetry
            {
                Comment = (string) jo["comment"],
                DisplayName = (string) jo["displayName"],
                Name = (string) jo["name"]
            };

            if (jo["@type"] is JArray type)
            {
                if (string.Compare((string) type[1], "SemanticType/Event",
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                    telemetry.Type = "Event";
                else if (string.Compare((string) type[1], "SemanticType/State",
                             StringComparison.InvariantCultureIgnoreCase) == 0)
                    telemetry.Type = "State";
            }
            else if (string.Compare((string)jo["@type"], "Telemetry", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                telemetry.Type = "Telemetry";
            }
            else if (string.Compare((string)jo["@type"], "Property", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                telemetry.Type = "Property";
            }
            else
            {
                throw new InvalidOperationException($"Unrecognized telemetry type '{(string)jo["@type"]}'");
            }

            return telemetry;
        }
    }
}