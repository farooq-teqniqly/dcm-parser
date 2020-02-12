using System.Collections.Generic;
using DcmParserLib.Abstractions;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Models
{
    public class ParserContext
    {
        public JObject Source { get; set; }

        public FileNode FileNode { get; set; }

        public List<ContentNode> ContentNodes { get; }

        public ParserContext()
        {
            ContentNodes = new List<ContentNode>();
        }
    }
}