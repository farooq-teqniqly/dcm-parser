using DcmParserLib;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests
{
    public class TelemetryJsonParserTests
    {
        [Fact]
        public void Parses_Json()
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