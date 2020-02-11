using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Abstractions
{
    public class ContentNodeParser
    {
        private readonly ParserContext context;

        public ContentNodeParser(ParserContext context)
        {
            this.context = context;
        }

        public void Parse()
        {
            var contents = context.Source["contents"];

            foreach (var content in contents)
            {
                if (content["@type"] is JArray)
                {
                    var type = (string) content["@type"][1];

                    if (string.Compare("Event", type, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {

                    }
                }
            }
        }
    }
}
