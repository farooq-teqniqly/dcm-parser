using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Abstractions
{
    public class ParserContext
    {
        public JObject Source { get; set; }

        public IDictionary<string, object> Data { get; set; }

        public ParserContext()
        {
            Data = new Dictionary<string, object>();
        }
    }
}