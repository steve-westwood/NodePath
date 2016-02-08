using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using FluentNHibernate.Mapping;

namespace DL.Mappings
{
	class VertexMap : ClassMap<Vertex>
	{
		public VertexMap()
		{
			Table("[dbo].[Vertices]");
			Id(x => x.ID)
				.GeneratedBy
				.Assigned()
				.Column("ID");
			Map(x => x.Name);
			HasMany(x => x.Edges)
				.KeyColumn("OriginID")
				.Cascade.All().Inverse();
		}
	}
}
