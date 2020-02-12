using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Abstractions;
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

        [Fact]
        public void Can_Parse_Content()
        {
            // Arrange
            var json = Resources.DeviceInterfaceFileJson;

            // Act
            var context = new ParserContext() { Source = JObject.Parse(json) };
            var parser = new ContentNodeParser(context);
            parser.Parse();

            // Assert
            var contents = context.ContentNodes.ToList();

            var telemetryContent = contents.OfType<TelemetryContentNode>().ToList();
            telemetryContent.Count.Should().Be(1);

            var eventContent = contents.OfType<EventContentNode>().ToList();
            eventContent.Count.Should().Be(9);

            var stateContent = contents.OfType<StateContentNode>().ToList();
            stateContent.Count.Should().Be(2);
        }
    }
}
