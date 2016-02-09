using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Services
{
	public interface ILogicService
	{
		void SaveVertices(Vertex[] vertices);
	}
}
