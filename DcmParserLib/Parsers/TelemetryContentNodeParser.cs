﻿using System;
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
            Context.ContentNodes.Add(new TelemetryContentNode
            {
                DisplayName = (string)Context.Source["displayName"],
                Name = (string)Context.Source["name"],
                Comment = (string)Context.Source["comment"]
            });
        }
    }
}
