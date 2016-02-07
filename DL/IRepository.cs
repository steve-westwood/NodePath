using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DL
{
	interface IRepository
	{
		ISession OpenSession();
	}
}
