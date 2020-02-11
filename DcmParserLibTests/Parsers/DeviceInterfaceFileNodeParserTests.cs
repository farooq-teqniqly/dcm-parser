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

namespace DcmParserLibTests.Parsers
{
    public class DeviceInterfaceFileNodeParserTests
    {
        [Fact]
        public void Can_Parse()
        {
            // Arrange
            var json = Resources.DeviceInterfaceFileJson;

            // Act
            var context = new ParserContext() {Source = JObject.Parse(json)};
            var parser = new DeviceInterfaceFileNodeParser(context);
            parser.Parse(new DeviceInterfaceFileNode());

            // Assert
            context.FileNode.Name.Should().Be("Machine");
            context.FileNode.Id.Should().Be("urn:marel:sensorx:machine:1");
        }
    }

    public class TelemetryContentNodeParserTests
    {
        [Fact]
        public void Can_Parse()
        {
            // Arrange
            var json = Resources.DeviceInterfaceFileJson;

            // Act
            var context = new ParserContext() { Source = JObject.Parse(json) };
            var parser = new TelemetryContentNodeParser(context);
            parser.Parse(new TelemetryContentNode());

            // Assert
            var contents = context.ContentNodes.ToList();
            contents.Count.Should().Be(1);
            contents[0].Name.Should().Be("telemetry");
            contents[0].DisplayName.Should().Be("Telemetry");
            contents[0].Comment.Should().Be("[type=sensorx.telemetry,version=1]");
        }
    }
}
