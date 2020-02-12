using System;
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
                    var semanticType = (string) content["@type"][1];

                    if (string.Compare("SemanticType/Event", semanticType,
                            StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var childContext = new ParserContext {Source = JObject.FromObject(content)};
                        var parser = new EventContentNodeParser(childContext);
                        parser.Parse(new EventContentNode());
                        context.ContentNodes.AddRange(childContext.ContentNodes);
                        continue;
                    }

                    if (string.Compare("SemanticType/State", semanticType,
                            StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        var childContext = new ParserContext {Source = JObject.FromObject(content)};
                        var parser = new StateContentNodeParser(childContext);
                        parser.Parse(new StateContentNode());
                        context.ContentNodes.AddRange(childContext.ContentNodes);
                        continue;
                    }
                }

                var type = (string) content["@type"];

                if (string.Compare("Telemetry", type,
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    var childContext = new ParserContext {Source = JObject.FromObject(content)};
                    var parser = new TelemetryContentNodeParser(childContext);
                    parser.Parse(new TelemetryContentNode());
                    context.ContentNodes.AddRange(childContext.ContentNodes);
                    continue;
                }

                if (string.Compare("Property", type,
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    var childContext = new ParserContext {Source = JObject.FromObject(content)};
                    var parser = new PropertyContentNodeParser(childContext);
                    parser.Parse(new PropertyContentNode());
                    context.ContentNodes.AddRange(childContext.ContentNodes);
                }
            }
        }
    }
}