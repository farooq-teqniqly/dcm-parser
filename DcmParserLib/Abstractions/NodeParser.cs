using DcmParserLib.Models;

namespace DcmParserLib.Abstractions
{
    public abstract class NodeParser : INodeParser
    {
        protected ParserContext Context { get; }

        protected NodeParser(ParserContext context)
        {
            Context = context;
        }

        public abstract void Parse(IParseable parseable);
    }
}