using ASPTest.Controllers;
using ASPTest.Models;
using ASPTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPUnitTest
{
	[TestClass]
	public class BeerTesting
	{
		private readonly BeerController _controller;
		private readonly IBeerServices _services;

		public BeerTesting()
		{
			_services = new BeerServices();
			_controller = new BeerController(_services);
		}

		[TestMethod]
		public void Get_Ok()
		{
			var result = _controller.Get();
			Assert.IsInstanceOfType(result,result.GetType());

		}

		[TestMethod]
		public void Get_Quantity()
		{
			var result = (OkObjectResult)_controller.Get();

			Assert.IsInstanceOfType(result.Value, typeof(List<Beer>));

			var beers = (List<Beer>?)result.Value;

			Assert.IsTrue(beers.Count > 0);
		}

		[TestMethod]
		public void GetById_Ok()
		{
			int id = 1;
			var result = _controller.GetById(id);
			Assert.IsInstanceOfType(result, result.GetType());
		}

		[TestMethod]
		public void GetById_Exists() 
		{
			// Arrange
			int id = 2;

			// Act
			var result = (OkObjectResult)_controller.GetById(id);

			// Assert
			Assert.IsInstanceOfType(result.Value, typeof(Beer));
			var beer = (Beer?)result.Value;

			Assert.IsTrue(beer != null);
			Assert.AreEqual(beer?.Id, id);
		}

		[TestMethod]
		public void GetById_NotFound()
		{
			// Arrange
			int id = 3;

			// Act
			var result = _controller.GetById(id);

			// Assert
			Assert.IsInstanceOfType(result, typeof(NotFoundResult));

		}
	}
}