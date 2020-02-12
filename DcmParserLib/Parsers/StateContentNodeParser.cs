using DcmParserLib.Abstractions;
using DcmParserLib.Models;

namespace DcmParserLib.Parsers
{
    public class StateContentNodeParser : NodeParser
    {
        public StateContentNodeParser(ParserContext context) : base(context)
        {
        }

        public override void Parse(IParseable parseable)
        {
            Context.ContentNodes.Add(new StateContentNode
            {
                DisplayName = (string) Context.Source["displayName"],
                Name = (string) Context.Source["name"],
                Comment = (string) Context.Source["comment"]
            });
        }
    }
}