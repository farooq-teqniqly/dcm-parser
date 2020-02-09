using DcmParserLib;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests
{
    public class FileIdJsonParserTests
    {
        [Fact]
        public void Parses_Json()
        {
            // Arrange
            var json = @"{
                           ""@id"":""urn:marel:sensorx:machine:1"",
                           ""@type"":""Interface"",
                           ""displayName"":""Machine"",
                           ""contents"":[

                           ]
                        }";

            // Act
            var fileId = new FileIdJsonParser().Parse(JObject.Parse(json));

            // Assert
            fileId.Id.Should().Be("urn:marel:sensorx:machine:1");
            fileId.DisplayName.Should().Be("Machine");
        }
    }
}