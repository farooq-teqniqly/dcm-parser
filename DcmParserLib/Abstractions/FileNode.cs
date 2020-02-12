using System.Collections.Generic;

namespace DcmParserLib.Abstractions
{
    public abstract class FileNode
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public List<ContentNode> Contents { get; set; }

        protected FileNode()
        {
            Contents = new List<ContentNode>();
        }
    }
}