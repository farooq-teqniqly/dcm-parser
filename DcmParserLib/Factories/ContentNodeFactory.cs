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
                var semanticType = (string) parserContext.Source["@type"][1];

                if (string.Compare("SemanticType/Event", semanticType,
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new EventContentNode();
                }
                else if (string.Compare("SemanticType/State", semanticType,
                             StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    contentNode = new StateContentNode();
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
                    contentNode = new PropertyContentNode
                    {
                        // Add the property schema here because there is no need to parse it.
                        Schema = new SimpleSchemaNode {Name = (string) parserContext.Source["schema"]}
                    };
                }
                
            }

            contentNode.Name = (string) parserContext.Source["name"];
            contentNode.DisplayName = (string) parserContext.Source["displayName"];
            contentNode.Comment = (string) parserContext.Source["comment"];

            return contentNode;
        }
    }
}