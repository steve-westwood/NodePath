using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DL;
using NHibernate;

namespace Services
{
    public class VertexService :ILogicService
    {
		private IRepository _repository;
		public VertexService(IRepository repository)
		{
			_repository = repository;
		}

		public void SaveVertices(Vertex[] vertices)
		{
			using (ISession dbSession = _repository.OpenSession())
			{
				// delete all vertices
				using (var transaction = dbSession.BeginTransaction())
				{
					dbSession.Delete("from Vertex v");
					dbSession.Flush();
					transaction.Commit();
				}

				foreach (var v in vertices)
				{
					using (var transaction = dbSession.BeginTransaction())
					{
						dbSession.Save(v);
						transaction.Commit();
					}
				}
			}

		}
    }
}
