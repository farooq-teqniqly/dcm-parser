using System.Linq;
using DcmParserLib.Abstractions;
using DcmParserLib.Factories;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests.Factories
{
    public class ContentNodeFactoryTests
    {
        [Fact]
        public void Returns_Telemetry_Content_Node()
        {
            // Arrange
            var factory = new ContentNodeFactory();
            var context = new ParserContext
            {
                Source = JObject.Parse(@"{
                                            ""@type"": ""Telemetry"",
                                            ""name"": ""telemetry"",
                                            ""displayName"": ""Telemetry"",
                                            ""comment"": ""[type=sensorx.telemetry,version=1]""
                                        }")
            };

            // Act
            var node = factory.CreateContentNode(context);

            // Assert
            node.Should().BeOfType<TelemetryContentNode>();
            node.DisplayName.Should().Be("Telemetry");
            node.Name.Should().Be("telemetry");
            node.Comment.Should().Be("[type=sensorx.telemetry,version=1]");
        }

        [Fact]
        public void Returns_Property_Content_Node()
        {
            // Arrange
            var factory = new ContentNodeFactory();
            var context = new ParserContext
            {
                Source = JObject.Parse(@"{
                                        ""@type"": ""Property"",
                                        ""name"": ""historicalDataUploadUrl"",
                                        ""displayName"": ""Historical data upload URL"",
                                        ""comment"": ""[type=sensorx.property,version=1]"",
                                        ""schema"": ""string"",
                                        ""writable"": true
                                    }
                                    ")
            };

            // Act
            var node = factory.CreateContentNode(context);

            // Assert
            node.Should().BeOfType<PropertyContentNode>();
            node.DisplayName.Should().Be("Historical data upload URL");
            node.Name.Should().Be("historicalDataUploadUrl");
            node.Comment.Should().Be("[type=sensorx.property,version=1]");
            node.Schema.Should().BeOfType<SimpleSchemaNode>();
            ((SimpleSchemaNode) node.Schema).Name.Should().Be("string");
        }

        [Fact]
        public void Returns_Event_Content_Node()
        {
            // Arrange
            var factory = new ContentNodeFactory();
            var context = new ParserContext
            {
                Source = JObject.Parse(@"{
                                            ""@type"": [
                                                ""Telemetry"",
                                                ""SemanticType/Marel/Event""
                                            ],
                                            ""name"": ""config"",
                                            ""displayName"": ""Configuration"",
                                            ""displayUnit"": ""JSON"",
                                            ""schema"":""integer"",
                                            ""comment"": ""[type=sensorx.event,version=1]""
                                        }")
            };

            // Act
            var node = factory.CreateContentNode(context);

            // Assert
            node.Should().BeOfType<EventContentNode>();
            node.DisplayName.Should().Be("Configuration");
            node.Name.Should().Be("config");
            node.Comment.Should().Be("[type=sensorx.event,version=1]");
            node.Schema.Should().BeOfType<SimpleSchemaNode>();
            ((SimpleSchemaNode) node.Schema).Name.Should().Be("integer");
        }

        [Fact]
        public void Returns_State_Content_Node()
        {
            // Arrange
            var factory = new ContentNodeFactory();
            var context = new ParserContext
            {
                Source = JObject.Parse(@"{
                                        ""@type"": [
                                            ""Telemetry"",
                                            ""SemanticType/Marel/State""
                                        ],
                                        ""name"": ""plutoState"",
                                        ""displayName"": ""Pluto State"",
                                        ""schema"":""integer"",
                                        ""comment"": ""[type=sensorx.state,version=1]""
                                    }")
            };

            // Act
            var node = factory.CreateContentNode(context);

            // Assert
            node.Should().BeOfType<StateContentNode>();
            node.DisplayName.Should().Be("Pluto State");
            node.Name.Should().Be("plutoState");
            node.Comment.Should().Be("[type=sensorx.state,version=1]");
            node.Schema.Should().BeOfType<SimpleSchemaNode>();
            ((SimpleSchemaNode)node.Schema).Name.Should().Be("integer");
        }
    }
}