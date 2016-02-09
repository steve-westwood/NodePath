using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Services
{
	public class ImporterService : IImporter
	{
		private string _localPath { get; set; }
		private List<FileInfo> _files = new List<FileInfo>();
		private IPathSetter _pathSetter;

		public ImporterService(IPathSetter pathSetter) 
		{
			_pathSetter = pathSetter;
			this.SetDirectory();
			this.GetFilesFromDirectory();
		}

		private void SetDirectory()
		{
			_localPath = _pathSetter.ReturnPath();
		}

		private void GetFilesFromDirectory()
		{
			FileInfo[] files = new FileInfo[] {};
			if (Directory.Exists(_localPath))
			{
				DirectoryInfo di = new DirectoryInfo(_localPath);
				_files.AddRange(di.GetFiles("*.xml"));
			}
		}

		public List<FileInfo> GetFiles()
		{
			return _files;
		}
	}
}
