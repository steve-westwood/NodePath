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
				.Cascade.All().Inverse().AsBag().Not.LazyLoad();
		}
	}
}
