using DcmParserLib.Abstractions;
using DcmParserLib.Models;

namespace DcmParserLib.Parsers
{
    public class EventContentNodeParser : NodeParser
    {
        public EventContentNodeParser(ParserContext context) : base(context)
        {
        }

        public override void Parse(IParseable parseable)
        {
            Context.ContentNodes.Add(new EventContentNode
            {
                DisplayName = (string) Context.Source["displayName"],
                Name = (string) Context.Source["name"],
                Comment = (string) Context.Source["comment"]
            });
        }
    }
}