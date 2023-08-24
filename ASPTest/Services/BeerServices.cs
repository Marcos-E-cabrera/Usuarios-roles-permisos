using ASPTest.Models;

namespace ASPTest.Services
{
	public class BeerServices : IBeerServices
	{
		private List<Beer> _beers = new List<Beer>()
		{
			new Beer() {Id =1 , Name="Corona",Brand = "Moreno" },
			new Beer() {Id =2 , Name="Pikantus",Brand = "Erdinger" }
		};



		public IEnumerable<Beer> Get() => _beers;
		

		public Beer? Get(int id) => _beers.FirstOrDefault(x => x.Id == id);
	}
}
