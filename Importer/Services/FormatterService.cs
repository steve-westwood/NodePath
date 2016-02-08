using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Core;
using Importer.Models;

namespace Importer.Services
{
	public class FormatterService: IFormatter
	{
		private FileInfo[] _files = new FileInfo[] { };
		private List<Vertex> _data = new List<Vertex>();

		public void InputData(FileInfo[] files)
		{
			_files = files;
		}

		public Vertex[] GetFormattedData()
		{
			if (_files.Length > 0)
			{
				DeserialiseData();
			}
			return _data.ToArray();
		}

		private void DeserialiseData()
		{
			List<Node> nodes = new List<Node>();
			XmlSerializer serializer = new XmlSerializer(typeof(Node));
			foreach(var file in _files)
			{
				using (TextReader reader = file.OpenText())
				{
					nodes.Add((Node)serializer.Deserialize(reader));
				}
			}
			foreach (var node in nodes)
			{
				_data.Add(node.MapNodeToVertex());
			}
		}
	}
}
