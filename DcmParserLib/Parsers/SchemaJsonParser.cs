using System;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Parsers
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

                    var typeString = (string) schemaObj["@type"];
                    var fieldParser = new FieldJsonParser();

                    if (string.Compare("Array", typeString, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var arraySchema = new Schema
                        {
                            Type = (string) schemaObj["@type"]
                        };

                        var arrayFields = schemaObj["elementSchema"]["fields"];


                        foreach (var arrayField in arrayFields)
                        {
                            var field = fieldParser.Parse(arrayField);
                            arraySchema.Fields.Add(field);
                        }

                        return arraySchema;
                    }

                    if (string.Compare("Object", typeString, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var objectSchema = new Schema
                        {
                            Type = typeString
                        };

                        var objectFields = schemaObj["fields"];

                        foreach (var objectField in objectFields)
                        {
                            var field = fieldParser.Parse(objectField);
                            objectSchema.Fields.Add(field);
                        }

                        return objectSchema;
                    }

                    if (string.Compare("Property", typeString, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var propertySchema = new Schema
                        {
                            Type = typeString
                        };

                        propertySchema.Fields.Add(new Field
                        {
                            DisplayName = schemaObj["displayName"],
                            DisplayUnit = 
                        });
                    }


                    }
                case JValue jv:
                    return new Schema {Type = (string) jv.Value};
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}