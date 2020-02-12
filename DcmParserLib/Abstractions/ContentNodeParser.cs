using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
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

                    if (string.Compare("SemanticType/Event", type,
                            StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var childContext = new ParserContext { Source = JObject.FromObject(content) };
                        var parser = new EventContentNodeParser(childContext);
                        parser.Parse(new EventContentNode());
                        this.context.ContentNodes.AddRange(childContext.ContentNodes);
                        continue;
                    }

                    if (string.Compare("SemanticType/State", type,
                            StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var childContext = new ParserContext { Source = JObject.FromObject(content) };
                        var parser = new StateContentNodeParser(childContext);
                        parser.Parse(new StateContentNode());
                        this.context.ContentNodes.AddRange(childContext.ContentNodes);
                        continue;
                    }
                }

                if (string.Compare("Telemetry", (string)content["@type"],
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    var childContext = new ParserContext {Source = JObject.FromObject(content)};
                    var parser = new TelemetryContentNodeParser(childContext);
                    parser.Parse(new TelemetryContentNode());
                    this.context.ContentNodes.AddRange(childContext.ContentNodes);
                    continue;
                }
            }
        }
    }
}
