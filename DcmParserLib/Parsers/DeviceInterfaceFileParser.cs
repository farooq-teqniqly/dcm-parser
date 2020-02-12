using DcmParserLib.Abstractions;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Parsers
{
    public class DeviceInterfaceFileParser
    {
        private readonly ParserContext context;
        private readonly IContentNodeFactory contentNodeFactory;
        private readonly ISchemaNodeFactory schemaNodeFactory;
        private readonly IFieldNodesFactory fieldNodesFactory;

        public DeviceInterfaceFileParser(
            ParserContext context,
            IContentNodeFactory contentNodeFactory,
            ISchemaNodeFactory schemaNodeFactory,
            IFieldNodesFactory fieldNodesFactory)
        {
            this.context = context;
            this.contentNodeFactory = contentNodeFactory;
            this.schemaNodeFactory = schemaNodeFactory;
            this.fieldNodesFactory = fieldNodesFactory;
        }

        public DeviceInterfaceFileNode Parse()
        {
            // parse file info
            var deviceInterfaceFileNode = new DeviceInterfaceFileNode
            {
                Id = (string) context.Source["@id"],
                DisplayName = (string) context.Source["displayName"]
            };

            // parse content nodes
            foreach (var tokenContent in context.Source["contents"])
            {
                var contentNodeContext = new ParserContext
                {
                    Source = JObject.FromObject(tokenContent)
                };

                var contentNode = contentNodeFactory.CreateContentNode(contentNodeContext);

                if (contentNode is InvalidContentNode) continue;

                // Parse schema if it isn't a simple schema in which case it was parsed by the ContentNodeFactory.

                if (tokenContent["schema"].Type != JTokenType.String)
                {
                    var schemaNodeContext = new ParserContext
                    {
                        Source = JObject.FromObject(tokenContent["schema"])
                    };

                    var schemaNode = schemaNodeFactory.CreateSchemaNode(schemaNodeContext);

                    if (schemaNode is SimpleSchemaNode) continue;
                    if (schemaNode is InvalidSchemaNode) continue;

                    // Parse schema fields
                    var fieldNodesContext = new ParserContext
                    {
                        Source = JObject.FromObject(tokenContent["schema"])
                    };

                    fieldNodesContext.Data.Add("SchemaType", schemaNode.GetType());

                    var fieldNodes = fieldNodesFactory.CreateFieldNodes(fieldNodesContext);

                    schemaNode.Fields.AddRange(fieldNodes);
                    contentNode.Schema = schemaNode;
                }


                deviceInterfaceFileNode.Contents.Add(contentNode);
            }

            return deviceInterfaceFileNode;
        }
    }
}