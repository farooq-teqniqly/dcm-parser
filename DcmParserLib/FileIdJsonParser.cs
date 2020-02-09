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
}