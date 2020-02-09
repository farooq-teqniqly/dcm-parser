using DcmParserLib.Parsers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests.Parsers
{
    public class SchemaJsonParserTests
    {
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

            var idField = fields[0];
            idField.Name.Should().Be("id");
            idField.Schema.Type.Should().Be("integer");

            var iFaceField = fields[1];
            iFaceField.Name.Should().Be("iface");
            iFaceField.Schema.Type.Should().Be("string");
        }

        [Fact]
        public void Parses_Object_Schema()
        {
            // Arrange
            var json = @"{
                   ""schema"":{
                      ""@type"":""Object"",
                      ""fields"":[
                         {
                            ""name"":""dateTime"",
                            ""displayName"":""Date time"",
                            ""schema"":""dateTime""
                         },
                         {
                            ""name"":""cabinetTemperature"",
                            ""displayName"":""Cabinet Temperature"",
                            ""displayUnit"":""C"",
                            ""schema"":""double""
                         }
                      ]
                   }
                }";

            // Act
            var schema = new SchemaJsonParser().Parse(JObject.Parse(json));

            // Assert
            var fields = schema.Fields.ToArray();
            fields.Length.Should().Be(2);

            var nameField = fields[0];
            nameField.Name.Should().Be("dateTime");
            nameField.Schema.Type.Should().Be("dateTime");

            var tempField = fields[1];
            tempField.Name.Should().Be("cabinetTemperature");
            tempField.Schema.Type.Should().Be("double");
            tempField.DisplayUnit.Should().Be("C");
        }

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
        public void Parses_Property_Schema()
        {
            // Arrange
            var json = @"{
                    ""@type"": ""Property"",
                    ""displayName"": ""Opc UA Address"",
                    ""description"": ""Address used to connect to the OPC UA endpoint. Needs to be in the format: opc.tcp//ip-address"",
                    ""name"": ""opcUaAddress"",
                    ""schema"": ""string"",
                    ""writable"": true
                }";

            // Act
            var schema = new SchemaJsonParser().Parse(JObject.Parse(json));

            // Assert
            schema.Type.Should().Be("Property");

            var fields = schema.Fields.ToArray();
            fields.Length.Should().Be(1);

            fields[0].DisplayName.Should().Be("Opc UA Address");
            fields[0].Name.Should().Be("opcUaAddress");

        }
    }
}