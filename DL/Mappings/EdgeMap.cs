using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
