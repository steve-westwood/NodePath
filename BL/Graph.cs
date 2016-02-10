using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Services
{
	public class Graph
	{
		private Vertex[] _nodes { get; set; }
		public Graph(Vertex[] nodes)
		{
			_nodes = nodes;
		}

		public int[] getDirections(int sourceVertex, int destinationVertex) 
		{
			//Initialization.
			Dictionary<int, int> nextVertexMap = new Dictionary<int, int>();
			int currentVertex = sourceVertex;

			//Queue
			List<int> queue = new List<int>();
			queue.Add(currentVertex);

			/*
			 * The set of visited nodes doesn't have to be a Map, and, since order
			 * is not important, an ordered collection is not needed. HashSet is 
			 * fast for add and lookup, if configured properly.
			 */
			List<int> visitedVertexs = new List<int>();
			visitedVertexs.Add(currentVertex);

			//Search.
			while (queue.Count > 0) {
				currentVertex = queue[queue.Count - 1]; 
				queue.Remove(currentVertex);
				if (currentVertex == destinationVertex) {
					//Look up of next node instead of previous.
					if (nextVertexMap.ContainsKey(currentVertex))
					{
						nextVertexMap[currentVertex] = currentVertex;
					}
					else
					{
						nextVertexMap.Add(currentVertex, currentVertex);
					}
					break;
				} else {
					Vertex currentVertexObj = null;
					foreach (var nextVertex in _nodes)
					{
						if (nextVertex.ID == currentVertex)
						{
							currentVertexObj = nextVertex;
							break;
						}
					}
					foreach (var edge in currentVertexObj.Edges)
					{
						if (!visitedVertexs.Contains(edge.DestinationID))
						{
							queue.Add(edge.DestinationID);
							visitedVertexs.Add(edge.DestinationID);

							//Look up of next node instead of previous.
							if (nextVertexMap.ContainsKey(currentVertex))
							{
								nextVertexMap[currentVertex] = edge.DestinationID;
							}
							else
							{
								nextVertexMap.Add(currentVertex, edge.DestinationID);
							}
						}
					}
				}
			}

			//If all nodes are explored and the destination node hasn't been found.
			if (currentVertex != destinationVertex) {
				throw new Exception("Destination node not found");
			}

			//Reconstruct path. No need to reverse.
			List<int> directions = new List<int>();
			foreach(KeyValuePair<int, int> map in nextVertexMap)
			{
				directions.Add(map.Key);
			}

			return directions.ToArray();
		}
	}
}
