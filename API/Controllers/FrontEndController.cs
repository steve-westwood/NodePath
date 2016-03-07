using System;
using System.Web.Http;
using Services;

namespace API.Controllers
{
    public class FrontEndController : ApiController
    {
		private readonly ILogicService _service;

		public FrontEndController(ILogicService service)
		{
			_service = service;
		}

		[HttpGet]
		[Route("frontend/get")]
		public IHttpActionResult Get()
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
