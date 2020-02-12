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

        public DeviceInterfaceFileParser(
            ParserContext context,
            IContentNodeFactory contentNodeFactory,
            ISchemaNodeFactory schemaNodeFactory)
        {
            this.context = context;
            this.contentNodeFactory = contentNodeFactory;
            this.schemaNodeFactory = schemaNodeFactory;
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
            }
        }
    }
}