using System.Collections.Generic;

namespace Core
{
	public class Vertex
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual IEnumerable<Edge> Edges { get; set; }
	}
}
