using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests.ImporterTests
{
	[TestFixture]
	public class EventSearchFilterServiceTests
	{
		private Importer.Services.ImporterService _importer;
		private Importer.Services.FormatterService _formatter;
		private readonly Mock<Importer.Services.IPathSetter> _mockPathSetter = new Mock<Importer.Services.IPathSetter>();

		[SetUp]
		public void SetUp()
		{
			var correctPath = AppDomain.CurrentDomain.BaseDirectory + "ImporterTests\\XmlData\\";
			_mockPathSetter.Setup(s => s.ReturnPath()).Returns(() => correctPath);
			_importer = new Importer.Services.ImporterService(_mockPathSetter.Object);
			_formatter = new Importer.Services.FormatterService();
		}

		[Test]
		public void Ensure_importer_returns_the_expected_amount_of_files_from_given_folder()
		{
			var files = _importer.GetFiles();

			Assert.AreEqual(3, files.Count);
		}

		[Test]
		public void Ensure_importer_returns_the_expected_files_from_given_folder()
		{
			var files = _importer.GetFiles();
			var fileNames = files.Select(file => file.Name).ToList();
		    bool allFilesFound = fileNames.Contains("amazon.xml")
				&& fileNames.Contains("ibm.xml")
				&& fileNames.Contains("paypal.xml");

			Assert.IsTrue(allFilesFound);
		}

		[Test]
		public void Ensure_formatter_returns_expected_objects_from_given_xml_files()
		{
		    var expectedData = new List<Core.Vertex>
		    {
		        new Core.Vertex
		        {
		            ID = 9,
		            Name = "Amazon",
		            Edges = new Core.Edge[] {new Core.Edge {OriginID = 9, DestinationID = 10}}
		        },
		        new Core.Vertex
		        {
		            ID = 4,
		            Name = "IBM",
		            Edges = new Core.Edge[] {}
		        },
		        new Core.Vertex
		        {
		            ID = 5,
		            Name = "Paypal",
		            Edges = new Core.Edge[]
		            {
		                new Core.Edge {OriginID = 5, DestinationID = 2},
		                new Core.Edge {OriginID = 5, DestinationID = 8},
		                new Core.Edge {OriginID = 5, DestinationID = 5},
		                new Core.Edge {OriginID = 5, DestinationID = 7}
		            }
		        }
		    };
		    // in alphabetical order
		    //amazon
		    //ibm
		    //paypal
		    var files = _importer.GetFiles();
			_formatter.InputData(files.ToArray());
			Core.Vertex[] formattedData = _formatter.GetFormattedData();
			var expectedJson = JsonConvert.SerializeObject((expectedData.ToArray()));
			var actualJson = JsonConvert.SerializeObject(formattedData);
			Assert.AreEqual(expectedJson, actualJson);
		}
	}
}
