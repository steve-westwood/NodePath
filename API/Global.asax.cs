using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		private readonly IWindsorContainer _container;

		public WebApiApplication()
		{
			this._container = new WindsorContainer().Install(FromAssembly.This());
		}

        protected void Application_Start()
        {
			GlobalConfiguration.Configure(WebApiConfig.Register);
			GlobalConfiguration.Configuration.DependencyResolver =
				new WindsorDependencyResolver(_container.Kernel);
        }

		public override void Dispose()
		{
			this._container.Dispose();
			base.Dispose();
		}
    }
}
