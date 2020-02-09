using System;
using DcmParserLib.Parsers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests.Parsers
{
    public class TelemetryJsonParserTests
    {
        [Fact]
        public void Parses_Event_Json()
        {
            // Arrange
            var json = @"{
                           ""@type"":[
                              ""Telemetry"",
                              ""SemanticType/Event""
                           ],
                           ""name"":""telemetry"",
                           ""displayName"":""Telemetry"",
                           ""comment"":""[type=sensorx.telemetry,version=1]"",
                           ""schema"":{

                           }
                        }";

            // Act
            var telemetry = new TelemetryJsonParser().Parse(JObject.Parse(json));

            // Assert
            telemetry.Type.Should().Be("Event");
        }

        [Fact]
        public void Parses_Property_Json()
        {
            // Arrange
            var json = @"{
	                ""@type"": ""Property"",
	                ""displayName"": ""Opc UA Address"",
	                ""description"": ""Description Text"",
	                ""name"": ""opcUaAddress"",
	                ""schema"": ""string"",
	                ""writable"": true
                }";

            // Act
            var telemetry = new TelemetryJsonParser().Parse(JObject.Parse(json));

            // Assert
            telemetry.DisplayName.Should().Be("Opc UA Address");
            telemetry.Type.Should().Be("Property");
            telemetry.Comment.Should().BeNullOrWhiteSpace();
            telemetry.Name.Should().Be("opcUaAddress");
        }

        [Fact]
        public void Parses_State_Json()
        {
            // Arrange
            var json = @"{
                           ""@type"":[
                              ""Telemetry"",
                              ""SemanticType/State""
                           ],
                           ""name"":""telemetry"",
                           ""displayName"":""Telemetry"",
                           ""comment"":""[type=sensorx.telemetry,version=1]"",
                           ""schema"":{

                           }
                        }";

            // Act
            var telemetry = new TelemetryJsonParser().Parse(JObject.Parse(json));

            // Assert
            telemetry.Type.Should().Be("State");
        }

        [Fact]
        public void Parses_Telemetry_Json()
        {
            // Arrange
            var json = @"{
                       ""@type"":""Telemetry"",
                       ""name"":""Telemetry Name"",
                       ""displayName"":""Telemetry Display Name"",
                       ""comment"":""[type=sensorx.telemetry,version=1]"",
                       ""schema"":{

                       }
                    }";
            // Act
            var telemetry = new TelemetryJsonParser().Parse(JObject.Parse(json));

            // Assert
            telemetry.DisplayName.Should().Be("Telemetry Display Name");
            telemetry.Type.Should().Be("Telemetry");
            telemetry.Comment.Should().Be("[type=sensorx.telemetry,version=1]");
            telemetry.Name.Should().Be("Telemetry Name");
        }

        [Fact]
        public void When_Unrecognized_Type_Throw_Exception()
        {
            // Arrange
            var json = @"{
	                ""@type"": ""Foo"",
	                ""displayName"": ""Opc UA Address"",
	                ""description"": ""Description Text"",
	                ""name"": ""opcUaAddress"",
	                ""schema"": ""string"",
	                ""writable"": true
                }";

            // Act

            Action action = () => new TelemetryJsonParser().Parse(JObject.Parse(json));

            // Assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage("Unrecognized telemetry type 'Foo'");
        }
    }
}