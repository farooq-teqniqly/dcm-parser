using System.Collections.Generic;

namespace DcmParserLib.Abstractions
{
    public abstract class SchemaNode
    {
        public List<FieldNode> Fields { get; set; }

        protected SchemaNode()
        {
            Fields = new List<FieldNode>();
        }
    }
}