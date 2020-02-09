using System;
using Newtonsoft.Json.Linq;

namespace DcmParserLib
{
    public class TelemetryJsonParser : IDcmJsonParser<Telemetry>
    {
        public Telemetry Parse(object obj)
        {
            var jo = (JObject)obj;
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
                telemetry.Type = (string) jo["@type"];
            }

            return telemetry;
        }
    }
}