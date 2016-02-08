using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Core;
using Importer.Services;

namespace Importer
{
	class Program
	{
		static void Main(string[] args)
		{
			// Registering
			var container = new WindsorContainer();
			container.Register(Component.For<IImporter>().ImplementedBy<ImporterService>().LifestyleTransient());
			container.Register(Component.For<IFormatter>().ImplementedBy<FormatterService>().LifestyleTransient());
			// Resolving
			var importer = container.Resolve<IImporter>();
			var formatter = container.Resolve<IFormatter>();

			// Perform import
			var files = importer.GetFiles();
			formatter.InputData(files.ToArray());
			Vertex[] data = formatter.GetFormattedData();

		}
	}
}
