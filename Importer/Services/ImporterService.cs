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

		public ImporterService() 
		{
			this.SetBaseDirectory();
			this.GetFilesFromDirectory();
		}

		private void SetBaseDirectory()
		{
			_localPath = AppDomain.CurrentDomain.BaseDirectory;
			_localPath += "XmlData\\";
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
