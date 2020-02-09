using DcmParserLib;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests
{
    public class FieldJsonParserTests
    {
        [Fact]
        public void Parses_Simple_Field()
        {
            // Arrange
            var json = @"{
                             ""name"":""dateTime"",
                             ""displayName"":""Date time"",
                             ""schema"":""dateTime schema""
                          }";
            
            // Act
            Field field = new FieldJsonParser().Parse(JObject.Parse(json));

            // Assert
            field.DisplayName.Should().Be("Date time");
            field.Name.Should().Be("dateTime");
            field.Schema.Should().Be("dateTime schema");
            field.DisplayUnit.Should().BeNullOrWhiteSpace();
        }

        [Fact]
        public void Parses_Field_With_Units()
        {
            // Arrange
            var json = @"{
                             ""name"":""dateTime"",
                             ""displayName"":""Date time"",
                             ""schema"":""dateTime schema"",
                             ""displayUnit"":""units"",

                          }";

            // Act
            var field = new FieldJsonParser().Parse(JObject.Parse(json));

            // Assert
            field.DisplayName.Should().Be("Date time");
            field.Name.Should().Be("dateTime");
            field.Schema.Should().Be("dateTime schema");
            field.DisplayUnit.Should().Be("units");
        }
    }
}