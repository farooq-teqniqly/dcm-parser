using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Abstractions;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Models
{
    public class ParserContext
    {
        public JObject Source { get; set; }

        public FileNode FileNode { get; set; }
    }
}
