using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Services
{
	public class LocalDirectoryService : IPathSetter
	{
		string _localPath { get; set; }
		public LocalDirectoryService()
		{
			_localPath = AppDomain.CurrentDomain.BaseDirectory;
			_localPath += "XmlData\\";
		}
		public string ReturnPath()
		{
			return _localPath;
		}
	}
}
