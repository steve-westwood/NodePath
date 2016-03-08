using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearchConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vertices = new List<Core.Vertex>
            {
                new Core.Vertex
                {
                    ID = 1,
                    Name = "1",
                    Edges = new[]
                    {
                        new Core.Edge {OriginID = 1, DestinationID = 2},
                        new Core.Edge {OriginID = 1, DestinationID = 3}
                    }
                },
                new Core.Vertex
                {
                    ID = 2,
                    Name = "2",
                    Edges = new[]
                    {
                        new Core.Edge {OriginID = 2, DestinationID = 4},
                        new Core.Edge {OriginID = 2, DestinationID = 5}
                    }
                },
                new Core.Vertex
                {
                    ID = 3,
                    Name = "3",
                    Edges = new[]
                    {
                        new Core.Edge {OriginID = 3, DestinationID = 6}
                    }
                },
                new Core.Vertex
                {
                    ID = 4,
                    Name = "4",
                    Edges = new[]
                    {
                        new Core.Edge {OriginID = 4, DestinationID = 1},
                        new Core.Edge {OriginID = 4, DestinationID = 6}
                    }
                },
                new Core.Vertex
                {
                    ID = 5,
                    Name = "5",
                    Edges = new Core.Edge[] {}
                },
                new Core.Vertex
                {
                    ID = 6,
                    Name = "6",
                    Edges = new Core.Edge[] {}
                }
            };

            DepthFirstSearch dfs = new DepthFirstSearch(vertices.ToArray());
            var path = dfs.GetShortestPath(1, 6);


        }
    }
}
