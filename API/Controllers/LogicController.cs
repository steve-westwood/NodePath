using System;
using System.Web.Http;
using Services;

namespace API.Controllers
{
    public class LogicController : ApiController
    {
		private readonly ILogicService _service;

		public LogicController(ILogicService service)
		{
			_service = service;
		}

		[HttpGet]
		[Route("logic/findshortestpath/{start}/{end}")]
		public IHttpActionResult Save(int start, int end)
		{
			try
			{
				var data = _service.FindShortestPath(start, end);
				return Ok(data);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
    }
}
