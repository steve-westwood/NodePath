using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Importer.Services;

namespace Importer
{
	public class WindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IImporter>().ImplementedBy<ImporterService>().LifestyleTransient());
			container.Register(Component.For<IFormatter>().ImplementedBy<FormatterService>().LifestyleTransient());
			container.Register(Component.For<IPathSetter>().ImplementedBy<LocalDirectoryService>().LifestyleTransient());
		}
	}
}
