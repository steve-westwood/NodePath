using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using DL.Mappings;
using NHibernate.Tool.hbm2ddl;

namespace DL
{
	public class Repository : IRepository
	{
		private static ISessionFactory _sessionFactory;

		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)

					InitializeSessionFactory();
				return _sessionFactory;
			}
		}

		private static void InitializeSessionFactory()
		{
			_sessionFactory = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008
				.ConnectionString(
					@"Server=(local);initial catalog=xxxxx;
					user=xxxxx;password=xxxxx;") // Modify your ConnectionString
					.ShowSql()
				)
				.Mappings(m =>
						  m.FluentMappings
							  .AddFromAssemblyOf<VertexMap>()
							  .AddFromAssemblyOf<EdgeMap>())
				.ExposeConfiguration(cfg => new SchemaExport(cfg)
												.Create(true, true))
				.BuildSessionFactory();
		}

		public ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}
