using DcmParserLib.Abstractions;

namespace DcmParserLib.Models
{
    public class StateContentNode : ContentNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }
}