using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;

namespace DcmParserLib
{
    public class FileIdJsonParser : IDcmJsonParser<FileId>
    {
        public FileId Parse(object obj)
        {
            var jo = (JObject) obj;

            return new FileId
            {
                Id = (string) jo["@id"],
                DisplayName = (string) jo["displayName"]
            };
        }
    }

    public class FieldJsonParser : IDcmJsonParser<Field>
    {
        public Field Parse(object obj)
        {
            var jo = (JObject)obj;

            var field = new Field
            {
                Name = (string) jo["name"],
                DisplayName = (string) jo["displayName"],
                DisplayUnit = (string)jo["displayUnit"]
            };

            if (jo["schema"] == null) return field;

            var schema = new SchemaJsonParser().Parse(jo["schema"]);
            field.Schema = schema;

            return field;
        }
    }
}