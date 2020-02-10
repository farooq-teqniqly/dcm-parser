using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Abstractions
{
    public abstract class NodeParser: INodeParser
    {
        protected ParserContext Context { get; }

        protected NodeParser(ParserContext context)
        {
            Context = context;
        }
        public abstract void Parse(IParseable parseable);
    }
}
