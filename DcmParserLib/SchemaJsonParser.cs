using System;
using Newtonsoft.Json.Linq;

namespace DcmParserLib
{
    public class SchemaJsonParser : IDcmJsonParser<Schema>
    {
        public Schema Parse(object obj)
        {
            switch (obj)
            {
                case JObject jo:
                {
                    var schemaObj = jo["schema"];

                    if (schemaObj.Type == JTokenType.String)
                        return new Schema
                        {
                            Type = (string) schemaObj
                        };

                    var arraySchema = new Schema
                    {
                        Type = (string) schemaObj["@type"]
                    };

                    var arrayFields = schemaObj["elementSchema"]["fields"];
                    var fieldParser = new FieldJsonParser();

                    foreach (var arrayField in arrayFields)
                    {
                        var field = fieldParser.Parse(arrayField);
                        arraySchema.Fields.Add(field);
                    }

                    return arraySchema;
                }
                case JValue jv:
                    return new Schema {Type = (string) jv.Value};
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}