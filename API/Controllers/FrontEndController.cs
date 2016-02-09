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
    public class FrontEndController : ApiController
    {
		private ILogicService _service;

		public FrontEndController(ILogicService service)
		{
			_service = service;
		}

		[HttpGet]
		[Route("frontend/get")]
		public IHttpActionResult Save(Vertex[] vertices)
		{
			try
			{
				var data = _service.GetVertices();
				return Ok(data);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
    }
}
