using System.Linq;
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
			DeleteAllVertices();
			using (ISession dbSession = _repository.OpenSession())
			{
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

		public void DeleteAllVertices()
		{
			using (ISession dbSession = _repository.OpenSession())
			{
				using (var transaction = dbSession.BeginTransaction())
				{
					dbSession.Delete("from Vertex v");
					dbSession.Flush();
					transaction.Commit();
				}
			}
		}


		public Vertex[] GetVertices()
		{
			Vertex[] vertices;
			using (ISession dbSession = _repository.OpenSession())
			{
				using (var transaction = dbSession.BeginTransaction())
				{
					vertices = dbSession.CreateCriteria<Vertex>("v")
									.SetFetchMode("v.Edges", FetchMode.Join)
									.List<Vertex>().ToArray();
					transaction.Commit();
				}
			}
			return vertices;
		}

		public int[] FindShortestPath(int start, int finish)
		{
			var vertices = GetVertices();

			Graph g = new Graph(vertices);
			var path = g.getDirections(start, finish);

			return path.ToArray();
		}
	}
}
