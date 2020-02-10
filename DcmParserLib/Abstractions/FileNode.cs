using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Abstractions
{
    public abstract class FileNode: IParseable
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ContentNode> ContentNodes { get; set; }
        public abstract void Accept(INodeParser nodeParser);

    }
}
