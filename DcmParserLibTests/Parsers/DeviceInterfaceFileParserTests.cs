using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Parsers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests.Parsers
{
    public class DeviceInterfaceFileParserTests
    {
        [Fact]
        public void Parses_Json()
        {
            // Arrange
            var json = @"{
	                        ""@id"": ""urn:marel:sensorx:machine:1"",
	                        ""@type"": ""Interface"",
	                        ""displayName"": ""Machine"",
	                        ""contents"": [
		                        {
			                        ""@type"": ""Telemetry"",
			                        ""name"": ""telemetry"",
			                        ""displayName"": ""Telemetry"",
			                        ""comment"": ""[type=sensorx.telemetry,version=1]"",
			                        ""schema"": {
				                        ""@type"": ""Object"",
				                        ""fields"": [
					                        {
						                        ""name"": ""dateTime"",
						                        ""displayName"": ""Date time"",
						                        ""schema"": ""dateTime""
					                        },
					                        {
						                        ""name"": ""cabinetTemperature"",
						                        ""displayName"": ""Cabinet Temperature"",
						                        ""displayUnit"": ""C"",
						                        ""schema"": ""double""
					                        }
				                        ]
			                        }
		                        }
	                        ]
                        }";

            // Act
            var deviceInterfaceFile = new DeviceInterfaceFileParser().Parse(JObject.Parse(json));

            // Assert
            var telemetries = deviceInterfaceFile.Telemetries.ToArray();
            telemetries.Length.Should().Be(1);

            var telemetry = telemetries[0];
            telemetry.Type.Should().Be("Telemetry");
            telemetry.Name.Should().Be("telemetry");
            telemetry.DisplayName.Should().Be("Telemetry");

            telemetry.Schema.Should().NotBeNull();
        }
    }
}
