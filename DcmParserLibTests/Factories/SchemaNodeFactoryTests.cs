using DcmParserLib.Abstractions;
using DcmParserLib.Factories;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests.Factories
{
    public class SchemaNodeFactoryTests
    {
        [Fact]
        public void Returns_Object_Schema_Node()
        {
            // Arrange
            var factory = new SchemaNodeFactory();

            var context = new ParserContext
            {
                Source = JObject.Parse(@"{
                                        ""@type"": ""Object""
                                    }")
            };

            // Act
            var node = factory.CreateSchemaNode(context);

            // Assert
            node.Should().BeOfType<ObjectSchemaNode>();
        }

        [Fact]
        public void Returns_Array_Schema_Node()
        {
            // Arrange
            var factory = new SchemaNodeFactory();

            var context = new ParserContext
            {
                Source = JObject.Parse(@"{
                                        ""@type"": ""Array""
                                    }")
            };

            // Act
            var node = factory.CreateSchemaNode(context);

            // Assert
            node.Should().BeOfType<ArraySchemaNode>();
        }
    }
}