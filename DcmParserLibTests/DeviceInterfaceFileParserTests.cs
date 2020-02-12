using System.IO;
using System.Linq;
using DcmParserLib.Abstractions;
using DcmParserLib.Factories;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DcmParserLibTests
{
    public class DeviceInterfaceFileParserTests
    {
        [Theory]
        [InlineData("./TestFiles/SensorX/sensorx.machine.interface.json", 3, 4, 0, 0)]
        [InlineData("./TestFiles/SensorX/sensorx.xrayGenerator.interface.json", 4, 0, 10, 2)]
        [InlineData("./TestFiles/SensorX/sensorx.conveyor.interface.json", 5, 0, 0, 2)]
        [InlineData("./TestFiles/SensorX/sensorx.xRaySensor.interface.json", 5, 5, 0, 4)]
        [InlineData("./TestFiles/ATC/atc.chainHealth.interface.json", 2, 0, 1, 0)]
        [InlineData("./TestFiles/ATC/atc.chillline.interface.json", 1, 1, 0, 0)]
        [InlineData("./TestFiles/ATC/atc.controller.interface.json", 0, 1, 1, 1)]
        [InlineData("./TestFiles/ATC/atc.dancers.interface.json", 1, 0, 1, 0)]
        [InlineData("./TestFiles/ATC/atc.smartWeigher.interface.json", 1, 0, 0, 0)]
        public void Can_Parse_Files(
            string fileName,
            int expectedTelemetryCount,
            int expectedEventCount,
            int expectedStateCount,
            int expectedPropertyCount)
        {
            // Arrange
            var context = new ParserContext {Source = JObject.Parse(File.ReadAllText(fileName))};

            // Act

            var parser = new DeviceInterfaceFileParser(
                context,
                new ContentNodeFactory(),
                new SchemaNodeFactory(),
                new FieldNodesFactory());

            var fileNode = parser.Parse();

            // Assert
            fileNode.Contents.OfType<TelemetryContentNode>().Count().Should().Be(expectedTelemetryCount);
            fileNode.Contents.OfType<EventContentNode>().Count().Should().Be(expectedEventCount);
            fileNode.Contents.OfType<StateContentNode>().Count().Should().Be(expectedStateCount);
            fileNode.Contents.OfType<PropertyContentNode>().Count().Should().Be(expectedPropertyCount);
        }
    }
}