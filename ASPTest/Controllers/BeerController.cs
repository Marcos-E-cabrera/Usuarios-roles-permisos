using ASPTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPTest.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BeerController : ControllerBase
	{
		private readonly IBeerServices _beerServices;

		public BeerController(IBeerServices services)
		{
			_beerServices = services;
		}

		[HttpGet]
		public IActionResult Get() => Ok( _beerServices.Get());

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var beer = _beerServices.Get(id);
			if ( beer == null )
				return NotFound();

			return Ok(beer);
		}

	}
}
