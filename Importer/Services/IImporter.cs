﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Services
{
	public interface IImporter
	{
		List<FileInfo> GetFiles();
	}
}
