using DcmParserLib.Abstractions;

namespace DcmParserLib.Models
{
    public class PropertyContentNode : ContentNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }
}