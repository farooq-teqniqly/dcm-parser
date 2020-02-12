using System;
using DcmParserLib.Abstractions;
using DcmParserLib.Models;

namespace DcmParserLib.Factories
{
    public class SchemaNodeFactory : ISchemaNodeFactory
    {
        public SchemaNode CreateSchemaNode(ParserContext parserContext)
        {
            SchemaNode schemaNode = new InvalidSchemaNode();

            var schemaType = (string) parserContext.Source["@type"];

            if (string.Compare("Object", schemaType, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                schemaNode = new ObjectSchemaNode();
            }

            if (string.Compare("Array", schemaType, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                schemaNode = new ArraySchemaNode();
            }

            return schemaNode;
        }
    }
}