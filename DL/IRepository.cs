using NHibernate;

namespace DL
{
	public interface IRepository
	{
		ISession OpenSession();
	}
}
