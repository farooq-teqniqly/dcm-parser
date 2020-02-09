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
                       ""@type"":""Telemetry Type"",
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
            telemetry.Type.Should().Be("Telemetry Type");
            telemetry.Comment.Should().Be("[type=sensorx.telemetry,version=1]");
            telemetry.Name.Should().Be("Telemetry Name");
        }
    }
}