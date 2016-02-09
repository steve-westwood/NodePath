using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Tests.ImporterTests
{
	[TestFixture]
	public class EventSearchFilterServiceTests
	{
		private Importer.Services.ImporterService _testSubject;
		private Mock<Importer.Services.IPathSetter> _mockPathSetter = new Mock<Importer.Services.IPathSetter>();

		[SetUp]
		public void SetUp()
		{
			var correctPath = AppDomain.CurrentDomain.BaseDirectory + "ImporterTests\\XmlData\\";
			_mockPathSetter.Setup(s => s.ReturnPath()).Returns(() => correctPath);
			_testSubject = new Importer.Services.ImporterService(_mockPathSetter.Object);

		}

		[Test]
		public void Ensure_importer_returns_the_expected_amount_of_files_from_given_folder()
		{
			var files = _testSubject.GetFiles();

			Assert.AreEqual(3, files.Count);
		}

		[Test]
		public void Ensure_importer_returns_the_expected_files_from_given_folder()
		{
			var files = _testSubject.GetFiles();
			var fileNames = new List<string>();
			foreach (var file in files)
			{
				fileNames.Add(file.Name);
			}
			bool allFilesFound = fileNames.Contains("amazon.xml")
				&& fileNames.Contains("ibm.xml")
				&& fileNames.Contains("paypal.xml");

			Assert.IsTrue(allFilesFound);
		}
	}
}
