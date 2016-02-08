using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Importer.Services
{
	public interface IFormatter
	{
		void InputData(FileInfo[] files);
		Vertex[] GetFormattedData();
	}
}
