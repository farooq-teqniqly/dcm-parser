using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Abstractions;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

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
