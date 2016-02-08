using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Core;

namespace Importer.Models
{
	[XmlRoot("node")]
	public class Node
	{
		[XmlElement("id")]
		public int ID { get; set; }
		[XmlElement("label")]
		public string Label { get; set; }
		[XmlArray(ElementName = "adjacentNodes")]
		[XmlArrayItem("id")]
		public int[] AdjacentNodes { get; set; }

		public Vertex MapNodeToVertex()
		{
			var edges = this.AdjacentNodes.Select(x => new Core.Edge { DestinationID = x, OriginID = this.ID });
			return new Vertex
			{
				ID = this.ID,
				Name = this.Label,
				Edges = edges
			};
		}
	}
}
