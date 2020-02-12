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

        public void Parse()
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

                // Parse content schema if not a property. A property's schema is added by the ContentNodeFactory.
                if (contentNode is PropertyContentNode) continue;

                var schemaNodeContext = new ParserContext
                {
                    Source = JObject.FromObject(tokenContent["schema"])
                };

                var schemaNode = schemaNodeFactory.CreateSchemaNode(schemaNodeContext);

                // Parse schema fields
                var fieldNodesContext = new ParserContext
                {
                    Source = JObject.FromObject(tokenContent["schema"])
                };

                fieldNodesContext.Data.Add("SchemaType", schemaNode.GetType());

                var fieldNodes = fieldNodesFactory.CreateFieldNodes(fieldNodesContext);
            }
        }
    }
}