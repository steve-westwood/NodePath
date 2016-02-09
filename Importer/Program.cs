using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
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

			// Perform import
			var files = importer.GetFiles();
			formatter.InputData(files.ToArray());
			Vertex[] data = formatter.GetFormattedData();

		}
	}
}
