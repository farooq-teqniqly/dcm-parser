using DcmParserLib.Abstractions;

namespace DcmParserLib.Models
{
    public class TelemetryContentNode : ContentNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }
}