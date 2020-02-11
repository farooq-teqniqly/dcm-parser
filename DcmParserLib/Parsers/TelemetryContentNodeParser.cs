using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Abstractions;
using DcmParserLib.Models;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Parsers
{
    public class TelemetryContentNodeParser : NodeParser
    {
        public TelemetryContentNodeParser(ParserContext context) : base(context)
        {
        }

        public override void Parse(IParseable parseable)
        {
            if (parseable is TelemetryContentNode node)
            {
                var contents = Context.Source["contents"];

                foreach (var content in contents)
                {
                    if (content["@type"] is JArray)
                    {
                        continue;
                    }

                    if (string.Compare("Telemetry", (string) content["@type"],
                            StringComparison.InvariantCultureIgnoreCase) != 0)
                    {
                        continue;
                    }

                    Context.ContentNodes.Add(new TelemetryContentNode
                    {
                        DisplayName = (string) content["displayName"],
                        Name = (string) content["name"],
                        Comment = (string) content["comment"]
                    });
                }
            }
        }
    }
}
