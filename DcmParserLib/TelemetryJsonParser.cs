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
                Name = (string) source["name"],
                Type = (string) source["@type"]
            };

            return telemetry;
        }
    }
}