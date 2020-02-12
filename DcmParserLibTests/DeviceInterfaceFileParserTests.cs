using DcmParserLib.Factories;
using DcmParserLib.Parsers;
using DcmParserLibTests.Properties;
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
            var context = new ParserContext { Source = JObject.Parse(Resources.DeviceInterfaceFileJson) };

            // Act

            var parser = new DeviceInterfaceFileParser(
                context, 
                new ContentNodeFactory(), 
                new SchemaNodeFactory(), 
                new FieldNodesFactory());

            parser.Parse();

            // Assert
        }
    }
}