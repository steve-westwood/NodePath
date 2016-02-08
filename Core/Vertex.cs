using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public class Vertex
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual IEnumerable<Edge> Edges { get; set; }
	}
}
