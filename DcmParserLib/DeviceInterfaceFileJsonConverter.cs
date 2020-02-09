using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DcmParserLib
{
    public class DeviceInterfaceFileJsonConverter : JsonConverter<DeviceInterfaceFile>
    {
        public override void WriteJson(JsonWriter writer, DeviceInterfaceFile value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override DeviceInterfaceFile ReadJson(
            JsonReader reader,
            Type objectType,
            DeviceInterfaceFile existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var fileId = new FileIdJsonParser().Parse(jo);

            foreach (var telemetryJson in jo["contents"])
            {
                var telemetry = new Telemetry
                {
                    Comment = (string) telemetryJson["comment"],
                    DisplayName = (string) telemetryJson["displayName"],
                    Name = (string) telemetryJson["name"],
                    Type = (string) telemetryJson["@type"]
                };

                var schemaJson = telemetryJson["schema"];

                var schema = new Schema
                {
                    Type = (string) schemaJson["@type"]
                };

                telemetry.Schema = schema;

                foreach (var fieldJson in schemaJson["fields"])
                {
                    var field = new Field
                    {
                        DisplayName = (string) fieldJson["displayName"],
                        DisplayUnit = (string) fieldJson["displayUnit"]
                        //Schema = new Schema {Type = (string) fieldJson["schema"]}
                    };

                    schema.Fields.Add(field);
                }
            }

            return null;
        }
    }
}