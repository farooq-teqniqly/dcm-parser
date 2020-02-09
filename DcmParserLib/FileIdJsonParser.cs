using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;

namespace DcmParserLib
{
    public class FileIdJsonParser : IDcmJsonParser<FileId>
    {
        public FileId Parse(JObject source)
        {
            return new FileId
            {
                Id = (string) source["@id"],
                DisplayName = (string) source["displayName"]
            };
        }
    }

    public class FieldJsonParser : IDcmJsonParser<Field>
    {
        public Field Parse(JObject source)
        {
            var field = new Field
            {
                Name = (string) source["name"],
                DisplayName = (string) source["displayName"],
                Schema = (string) source["schema"],
                DisplayUnit = (string)source["displayUnit"]
            };

            return field;
        }
    }
}