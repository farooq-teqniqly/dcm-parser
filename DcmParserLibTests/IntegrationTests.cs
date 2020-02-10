using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
using DcmParserLibTests.Properties;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests
{
    public class IntegrationTests
    {
        [Fact]
        public void Parses_Device_Interface_File()
        {
            // Arrange
            var parserContext = new ParserContext {Source = JObject.Parse(Resources.DeviceInterfaceFileJson)};
            var parser = new DeviceInterfaceFileNodeParser(parserContext);
            var node = new DeviceInterfaceFileNode();

            // Act
            parser.Parse(node);

            // Assert
            var fileNode = parserContext.FileNode;
            fileNode.Id.Should().Be("urn:marel:sensorx:machine:1");
            fileNode.Name.Should().Be("Machine");
        }
    }
}
