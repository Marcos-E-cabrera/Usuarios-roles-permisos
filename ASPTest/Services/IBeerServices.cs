using ASPTest.Models;

namespace ASPTest.Services
{
	public interface IBeerServices
	{
		/// <returns>Regresa toda la informacion de las beers</returns>
		public IEnumerable<Beer> Get();

		/// <returns>Regresa solo una beer, pueden ser NULL </returns>
		public Beer? Get(int id);

	}
}
