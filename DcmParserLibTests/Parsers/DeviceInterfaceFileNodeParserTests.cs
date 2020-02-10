using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DcmParserLib.Models;
using DcmParserLib.Parsers;
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
            var json = @"{
                        ""@id"": ""urn:marel:sensorx:machine:1"",
                        ""@type"": ""Interface"",
                        ""displayName"": ""Machine""
                    }";

            // Act
            var context = new ParserContext() {Source = JObject.Parse(json)};
            var parser = new DeviceInterfaceFileNodeParser(context);
            parser.Parse(new DeviceInterfaceFileNode());

            // Assert
            context.FileNode.Name.Should().Be("Machine");
            context.FileNode.Id.Should().Be("urn:marel:sensorx:machine:1");
        }
    }
}
