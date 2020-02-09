using DcmParserLib.Parsers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests.Parsers
{
    public class FieldJsonParserTests
    {
        [Fact]
        public void Parses_Field()
        {
            // Arrange
            var json = @"{
                             ""name"":""dateTime"",
                             ""displayName"":""Date time""
                          }";

            // Act
            var field = new FieldJsonParser().Parse(JObject.Parse(json));

            // Assert
            field.DisplayName.Should().Be("Date time");
            field.Name.Should().Be("dateTime");
            field.DisplayUnit.Should().BeNullOrWhiteSpace();
        }

        [Fact]
        public void Parses_Field_With_Unit()
        {
            // Arrange
            var json = @"{
                             ""name"":""dateTime"",
                             ""displayName"":""Date time"",
                             ""displayUnit"":""units"",

                          }";

            // Act
            var field = new FieldJsonParser().Parse(JObject.Parse(json));

            // Assert
            field.DisplayName.Should().Be("Date time");
            field.Name.Should().Be("dateTime");
            field.DisplayUnit.Should().Be("units");
        }
    }
}