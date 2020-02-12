using DcmParserLib.Abstractions;
using DcmParserLib.Models;

namespace DcmParserLib.Parsers
{
    public class DeviceInterfaceFileNodeParser : NodeParser
    {
        public DeviceInterfaceFileNodeParser(ParserContext context) : base(context)
        {
        }

        public override void Parse(IParseable parseable)
        {
            if (parseable is DeviceInterfaceFileNode node)
            {
                node.Id = (string) Context.Source["@id"];
                node.Name = (string) Context.Source["displayName"];
                Context.FileNode = node;
            }
        }
    }
}