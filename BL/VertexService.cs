﻿using System;
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
			var vertices = new Vertex[] { };
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
			var path = new List<int>();
			var vertices = GetVertices();
			var dist = 1;

			Graph g = new Graph();
			foreach (var vertex in vertices)
			{
				var edges = new Dictionary<int, int>();
				foreach(var edge in vertex.Edges){
					edges.Add(edge.DestinationID, dist);
				}
				g.add_vertex(vertex.ID, edges);
			}
			path.Add(start);
			g.shortest_path(start, finish).ForEach(x => path.Add(x));
			path.Add(finish);

			return path.ToArray();
		}
	}
}
