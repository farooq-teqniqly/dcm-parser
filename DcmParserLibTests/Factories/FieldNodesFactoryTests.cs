using System.Linq;
using DcmParserLib.Abstractions;
using DcmParserLib.Factories;
using DcmParserLib.Models;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests.Factories
{
    public class FieldNodesFactoryTests
    {
        [Fact]
        public void Can_Parse_Object_Schema_Fields()
        {
            // Arrange
            var json = @"{
                ""@type"": ""Object"",
                ""fields"": [{
                        ""name"": ""dateTime"",
                        ""displayName"": ""Date time"",
                        ""schema"": ""dateTime""
                    }, {
                        ""name"": ""cabinetTemperature"",
                        ""displayName"": ""Cabinet Temperature"",
                        ""displayUnit"": ""C"",
                        ""schema"": ""double""
                    }
                ]
            }";

            var context = new ParserContext {Source = JObject.Parse(json)};
            context.Data.Add("SchemaType", typeof(ObjectSchemaNode));

            var factory = new FieldNodesFactory();

            // Act
            var fieldNodes = factory.CreateFieldNodes(context).ToList();

            // Assert
            fieldNodes.Count.Should().Be(2);

            var dateTimeField = fieldNodes[0];
            dateTimeField.Name.Should().Be("dateTime");
            dateTimeField.DisplayName.Should().Be("Date time");
            dateTimeField.DisplayUnit.Should().BeNullOrWhiteSpace();

            var dateTimeFieldSchema = (SimpleSchemaNode) dateTimeField.Schema;
            dateTimeFieldSchema.Name.Should().Be("dateTime");

            var temperatureField = fieldNodes[1];
            temperatureField.Name.Should().Be("cabinetTemperature");
            temperatureField.DisplayName.Should().Be("Cabinet Temperature");
            temperatureField.DisplayUnit.Should().Be("C");

            var temperatureFieldSchema = (SimpleSchemaNode) temperatureField.Schema;
            temperatureFieldSchema.Name.Should().Be("double");
        }

        [Fact]
        public void Can_Parse_Array_Schema_Fields()
        {
            // Arrange
            var json = @"{
                    ""@type"":""Array"",
                    ""elementSchema"":{
                       ""@type"":""Object"",
                       ""fields"":[
                          {
                             ""name"":""package"",
                             ""schema"":""string""
                          },
                          {
                             ""name"":""installed"",
                             ""schema"":""string""
                          }
                       ]
                    }
                 }";

            var context = new ParserContext {Source = JObject.Parse(json)};
            context.Data.Add("SchemaType", typeof(ArraySchemaNode));

            var factory = new FieldNodesFactory();

            // Act
            var fieldNodes = factory.CreateFieldNodes(context).ToList();

            // Assert
            fieldNodes.Count.Should().Be(2);

            var packageField = fieldNodes[0];
            packageField.Name.Should().Be("package");
            packageField.DisplayName.Should().BeNullOrWhiteSpace();
            packageField.DisplayUnit.Should().BeNullOrWhiteSpace();

            var packageFieldSchema = (SimpleSchemaNode) packageField.Schema;
            packageFieldSchema.Name.Should().Be("string");

            var installedField = fieldNodes[1];
            installedField.Name.Should().Be("installed");
            installedField.DisplayName.Should().BeNullOrWhiteSpace();
            installedField.DisplayUnit.Should().BeNullOrWhiteSpace();

            var installedFieldSchema = (SimpleSchemaNode) installedField.Schema;
            installedFieldSchema.Name.Should().Be("string");
        }
    }
}