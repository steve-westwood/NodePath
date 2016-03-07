using Core;
using FluentNHibernate.Mapping;

namespace DL.Mappings
{
	class EdgeMap : ClassMap<Edge>
	{
		public EdgeMap()
		{
			Table("[dbo].[Edges]"); 
			CompositeId()
				.KeyProperty(x => x.OriginID)
				.KeyProperty(x => x.DestinationID);
		}
	}
}
