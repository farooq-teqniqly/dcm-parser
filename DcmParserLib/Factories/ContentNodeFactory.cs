using System;
using DcmParserLib.Abstractions;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Factories
{
    public class ContentNodeFactory : IContentNodeFactory
    {
        public ContentNode CreateContentNode(ParserContext parserContext)
        {
            ContentNode contentNode = new InvalidContentNode();

            if (parserContext.Source["@type"] is JArray)
            {
                var rootType = (string)parserContext.Source["@type"][0];
                var semanticType = (string) parserContext.Source["@type"][1];

                if (string.Compare("SemanticType/Marel/Event", semanticType,
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new EventContentNode();
                }
                else if (string.Compare("SemanticType/Marel/State", semanticType,
                             StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new StateContentNode();
                }
                else if (string.Compare("SemanticType/Marel/State", semanticType,
                             StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new StateContentNode();
                }
                else if (string.Compare("Telemetry", rootType, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new TelemetryContentNode();
                }
            }
            else
            {
                var type = (string) parserContext.Source["@type"];

                if (string.Compare("Telemetry", type,
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new TelemetryContentNode();
                }
                else if (string.Compare("Property", type,
                             StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new PropertyContentNode();
                }
                
            }

            if (parserContext.Source["schema"]?.Type == JTokenType.String)
            {
                contentNode.Schema = new SimpleSchemaNode
                {
                    Name = (string) parserContext.Source["schema"]
                };
            }

            contentNode.Name = (string) parserContext.Source["name"];
            contentNode.DisplayName = (string) parserContext.Source["displayName"];
            contentNode.Comment = (string) parserContext.Source["comment"];

            return contentNode;
        }
    }
}