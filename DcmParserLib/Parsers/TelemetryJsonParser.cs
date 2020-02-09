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

                return telemetry;
            }

            var typeString = (string) jo["@type"];

            if (string.Compare(typeString, "Telemetry", StringComparison.InvariantCultureIgnoreCase) == 0 ||
                string.Compare(typeString, "Property", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                telemetry.Type = typeString;
            }
            else
            {
                throw new InvalidOperationException($"Unrecognized telemetry type '{(string)jo["@type"]}'");
            }

            return telemetry;
        }
    }
}