using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using Services;

namespace API.Controllers
{
    public class InstallerController : ApiController
    {
		private readonly ILogicService _service;

		public InstallerController(ILogicService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("installer/save")]
		public IHttpActionResult Save(Vertex[] vertices)
		{
			try
			{
				_service.SaveVertices(vertices);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
    }
}
