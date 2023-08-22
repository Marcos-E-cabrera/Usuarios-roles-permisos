using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models.ViewModels
{
	// Clase separada de la EntityFramework, esto es una clase de Formulario
	public class BeerViewModel
	{
		[Required]
		[Display(Name="Nombre")]
		public string Name { get; set; }

		[Required] // para que sea obligatorio
		[Display(Name = "Marca")]
		public int BrandId { get; set; }
	}
}
