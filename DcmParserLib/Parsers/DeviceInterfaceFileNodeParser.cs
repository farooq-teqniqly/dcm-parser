using DcmParserLib.Abstractions;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Parsers
{
    public class DeviceInterfaceFileNodeParser : NodeParser
    {
        private readonly IContentNodeParserFactory contentNodeParserFactory;

        public DeviceInterfaceFileNodeParser(
            ParserContext context,
            IContentNodeParserFactory contentNodeParserFactory) : base(context)
        {
            this.contentNodeParserFactory = contentNodeParserFactory;
        }

        public override void Parse(IParseable parseable)
        {
            if (!(parseable is DeviceInterfaceFileNode deviceInterfaceFileNode)) return;

            deviceInterfaceFileNode.Id = (string)Context.Source["@id"];
            deviceInterfaceFileNode.Name = (string)Context.Source["displayName"];
            Context.FileNode = deviceInterfaceFileNode;

            foreach (var content in Context.Source["contents"])
            {
                var parser = contentNodeParserFactory.CreateParser(JObject.FromObject(content));

            }
        }
    }
}