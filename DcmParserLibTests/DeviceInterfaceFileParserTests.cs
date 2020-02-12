using DcmParserLib.Factories;
using DcmParserLib.Parsers;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests
{
    public class DeviceInterfaceFileParserTests
    {
        [Fact]
        public void Can_Parse_File()
        {
            // Arrange
            var json = @"{
                        ""@id"": ""urn:marel:sensorx:machine:1"",
                        ""@type"": ""Interface"",
                        ""displayName"": ""Machine"",
                        ""contents"": [{
                                ""@type"": ""Property"",
                                ""name"": ""systemVersion"",
                                ""displayName"": ""System Version"",
                                ""comment"": ""[type=sensorx.property,version=1]"",
                                ""schema"": ""string""
                            }
                        ]
                    }";

            // Act
            var context = new ParserContext {Source = JObject.Parse(json)};
            var parser = new DeviceInterfaceFileParser(context, new ContentNodeFactory(), new SchemaNodeFactory());
            parser.Parse();

            // Assert
        }
    }
}