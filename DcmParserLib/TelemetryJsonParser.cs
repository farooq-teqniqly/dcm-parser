using System;
using Newtonsoft.Json.Linq;

namespace DcmParserLib
{
    public class TelemetryJsonParser : IDcmJsonParser<Telemetry>
    {
        public Telemetry Parse(JObject source)
        {
            var telemetry = new Telemetry
            {
                Comment = (string) source["comment"],
                DisplayName = (string) source["displayName"],
                Name = (string) source["name"]
            };

            if (source["@type"] is JArray type)
            {
                if (string.Compare((string) type[1], "SemanticType/Event",
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    telemetry.Type = "Event";
                }
                else if (string.Compare((string)type[1], "SemanticType/State",
                                StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    telemetry.Type = "State";
                }
            }
            else
            {
                telemetry.Type = (string) source["@type"];
            }

            return telemetry;
        }
    }
}