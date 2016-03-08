using System.Collections.Generic;
using System.Linq;
using Core;

namespace Services
{
    public class DepthFirstSearch
    {
        private readonly Vertex[] _nodes;
        private List<int> _visitedNodes = new List<int>(); 
        private List<List<int>> _successfulPaths = new List<List<int>>(); 
        private List<int> _currentPath = new List<int>(); 
        public DepthFirstSearch(Vertex[] nodes)
        {
            _nodes = nodes;
        }

        public int[] GetShortestPath(int sourceVertexId, int destinationVertexId)
        {
            var v = (from n in _nodes
                     where n.ID == sourceVertexId
                     select n).FirstOrDefault();
            Search(v, destinationVertexId);
            int length = _nodes.Length;
            int[] path = new int[] {};
            foreach (var p in _successfulPaths)
            {
                if (p.Count < length)
                    path = p.ToArray();
            }
            return path;
        }

        private void Search(Vertex v, int destinationId)
        {
            _visitedNodes.Add(v.ID);
            _currentPath.Add(v.ID);
            foreach (Edge e in v.Edges)
            {
                if (e.DestinationID == destinationId)
                {
                    // do not mark destination as visited
                    // this allows search to reach destination via different routes
                    // add current path to successful paths (fake last step!)
                    _currentPath.Add(e.DestinationID);
                    _successfulPaths.Add(_currentPath.ToList());
                    _currentPath.Remove(e.DestinationID); //reverse
                }
                else
                {
                    if (!_visitedNodes.Contains(e.DestinationID))
                    {
                        var w = (from n in _nodes
                            where n.ID == e.DestinationID
                            select n).FirstOrDefault();
                        Search(w, destinationId);
                    }
                }
            }
            _currentPath.Remove(v.ID); //reverse
        }

    }
}
