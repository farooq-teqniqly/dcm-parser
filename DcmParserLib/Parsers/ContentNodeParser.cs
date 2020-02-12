using System;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Parsers
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
                        ParseEventContent(content);
                        continue;
                    }

                    if (string.Compare("SemanticType/State", semanticType,
                            StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        ParseStateContent(content);
                        continue;
                    }
                }

                var type = (string) content["@type"];

                if (string.Compare("Telemetry", type,
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    ParseTelemetryContent(content);
                    continue;
                }

                if (string.Compare("Property", type,
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    ParsePropertyContent(content);
                    continue;
                }
            }
        }

        private void ParsePropertyContent(JToken content)
        {
            var childContext = new ParserContext {Source = JObject.FromObject(content)};
            var parser = new PropertyContentNodeParser(childContext);
            parser.Parse(new PropertyContentNode());
            context.ContentNodes.AddRange(childContext.ContentNodes);
        }

        private void ParseTelemetryContent(JToken content)
        {
            var childContext = new ParserContext {Source = JObject.FromObject(content)};
            var parser = new TelemetryContentNodeParser(childContext);
            parser.Parse(new TelemetryContentNode());
            context.ContentNodes.AddRange(childContext.ContentNodes);
        }

        private void ParseStateContent(JToken content)
        {
            var childContext = new ParserContext {Source = JObject.FromObject(content)};
            var parser = new StateContentNodeParser(childContext);
            parser.Parse(new StateContentNode());
            context.ContentNodes.AddRange(childContext.ContentNodes);
        }

        private void ParseEventContent(JToken content)
        {
            var childContext = new ParserContext {Source = JObject.FromObject(content)};
            var parser = new EventContentNodeParser(childContext);
            parser.Parse(new EventContentNode());
            context.ContentNodes.AddRange(childContext.ContentNodes);
        }
    }
}