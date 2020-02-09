using System.Linq;
using DcmParserLib;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests
{
    public class SchemaJsonParserTests
    {
        [Fact]
        public void Parses_Simple_Schema()
        {
            // Arrange
            var json = @"{
                             ""name"":""dateTime"",
                             ""displayName"":""Date time"",
                             ""schema"":""dateTime""
                          }";

            // Act
            var schema = new SchemaJsonParser().Parse(JObject.Parse(json));

            // Assert
            schema.Type.Should().Be("dateTime");
        }

        [Fact]
        public void Parses_Array_Schema()
        {
            // Arrange
            var json = @"{
                       ""schema"":{
                          ""@type"":""Array"",
                          ""elementSchema"":{
                             ""@type"":""Object"",
                             ""fields"":[
                                {
                                   ""name"":""id"",
                                   ""schema"":""integer""
                                },
                                {
                                   ""name"":""iface"",
                                   ""schema"":""string""
                                }
                             ]
                          }
                       }
                    }";

            // Act
            var schema = new SchemaJsonParser().Parse(JObject.Parse(json));

            // Assert
            schema.Type.Should().Be("Array");
            
            var fields = schema.Fields.ToArray();
            fields.Length.Should().Be(2);

            //var idField = fields[0];
            //idField.Name.Should().Be("id");
            //idField.Schema[0].

        }
    }
}