﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Services
{
	public interface IExporter
	{
		void Export(Core.Vertex[] itemsToExport);
	}
}
