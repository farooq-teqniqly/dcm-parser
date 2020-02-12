using DcmParserLib.Abstractions;
using DcmParserLib.Models;

namespace DcmParserLib.Parsers
{
    public class TelemetryContentNodeParser : NodeParser
    {
        public TelemetryContentNodeParser(ParserContext context) : base(context)
        {
        }

        public override void Parse(IParseable parseable)
        {
            Context.ContentNodes.Add(new TelemetryContentNode
            {
                DisplayName = (string) Context.Source["displayName"],
                Name = (string) Context.Source["name"],
                Comment = (string) Context.Source["comment"]
            });
        }
    }
}