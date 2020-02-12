using System;
using System.Collections.Generic;
using DcmParserLib.Abstractions;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
using Newtonsoft.Json.Linq;

namespace DcmParserLib.Factories
{
    public class FieldNodesFactory : IFieldNodesFactory
    {
        public IEnumerable<FieldNode> CreateFieldNodes(ParserContext parserContext)
        {
            var schemaNodeType = (Type) parserContext.Data["SchemaType"];

            if (schemaNodeType == typeof(ObjectSchemaNode))
            {
                foreach (var fieldToken in parserContext.Source["fields"])
                {
                    if (fieldToken["schema"].Type == JTokenType.String)
                    {
                        yield return new FieldNode
                        {
                            Schema = new SimpleSchemaNode {Name = (string) fieldToken["schema"]},
                            Name = (string) fieldToken["name"],
                            DisplayName = (string) fieldToken["displayName"],
                            DisplayUnit = (string) fieldToken["displayUnit"]
                        };
                    }
                }
            }
            else if (schemaNodeType == typeof(ArraySchemaNode))
            {
                foreach (var fieldToken in parserContext.Source["elementSchema"]["fields"])
                {
                    if (fieldToken["schema"].Type == JTokenType.String)
                    {
                        yield return new FieldNode
                        {
                            Schema = new SimpleSchemaNode {Name = (string) fieldToken["schema"]},
                            Name = (string) fieldToken["name"]
                        };
                    }
                }
            }
        }
    }
}