using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using DL;
using NHibernate;

namespace API.Controllers
{
    public class InstallerController : ApiController
    {
		private IRepository _repository;
		private ISession _dbSession;

		public InstallerController(IRepository repository)
		{
			_repository = repository;
		}

		[HttpPost]
		[Route("installer/save")]
		public IHttpActionResult Save(Vertex[] vertices)
		{
			var errors = new List<string>();
			try
			{
				foreach(var v in vertices)
				{
					using (_dbSession = _repository.OpenSession()) {
						using (ITransaction transaction = _dbSession.BeginTransaction())
						{
							var newVertex = _dbSession.Save(v);
							transaction.Commit();
						}
					}
				}
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
    }
}
