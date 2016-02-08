using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using API.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DL;

namespace API
{
	public class WindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container
				.Register(Classes.FromThisAssembly().BasedOn<ApiController>());
			container
				.Register(Component.For<IRepository>().ImplementedBy<Repository>().LifestyleTransient());
		}
	}
}