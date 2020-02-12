using DcmParserLib.Abstractions;

namespace DcmParserLib.Models
{
    public class DeviceInterfaceFileNode : FileNode
    {
        public override void Accept(INodeParser nodeParser)
        {
            nodeParser.Parse(this);
        }
    }
}