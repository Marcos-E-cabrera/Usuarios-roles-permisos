using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
	// ESTO ES SOLO PARA TRABAJAR EN BACKEND
	[Route("api/[controller]")]
	[ApiController]
	public class ApiBeerController : ControllerBase
	{
		private readonly PubContext _Context;

		public ApiBeerController( PubContext context)
		{
			_Context = context;
		}

		// VA A GENERAR UNA LISTA EN FORMATO JSON
		public async Task<List<BeerBrandViewModel>> Get()
			=> await _Context.Beers.Include(b => b.BeerNavigation.Name)
			.Select(b => new BeerBrandViewModel()
			{
				Name = b.Name,
				Brand = b.BeerNavigation.Name
			})
			.ToListAsync();
	}
}
