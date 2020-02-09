using Newtonsoft.Json.Linq;

namespace DcmParserLib
{
    public interface IDcmJsonParser<T> where T : class
    {
        T Parse(JObject source);
    }
}