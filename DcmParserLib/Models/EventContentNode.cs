using DcmParserLib.Abstractions;

namespace DcmParserLib.Models
{
    public class EventContentNode : ContentNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }
}