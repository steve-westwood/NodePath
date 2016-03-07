using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Core;
using Importer.Services;

namespace Importer
{
	class Program
	{
		static void Main(string[] args)
		{
			// Registering
			var container = new WindsorContainer().Install(FromAssembly.This());
			// Resolving
			var importer = container.Resolve<IImporter>();
			var formatter = container.Resolve<IFormatter>();
			var exporter = container.Resolve<IExporter>();

			// Perform import
			var files = importer.GetFiles();
			Console.WriteLine("files parsed: {0}", files.Count.ToString());
			formatter.InputData(files.ToArray());
			Vertex[] data = formatter.GetFormattedData();
			Console.WriteLine("nodes to import: {0}", data.Length.ToString());
			Console.WriteLine("importing nodes... (this may take a few seconds)", data.Length.ToString());
			exporter.Export(data);
			Console.ReadLine();

		}
	}
}
