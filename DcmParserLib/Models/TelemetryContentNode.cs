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

    public class EventContentNode : ContentNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }

    public class StateContentNode : ContentNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }

    public class PropertyContentNode : ContentNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }
}