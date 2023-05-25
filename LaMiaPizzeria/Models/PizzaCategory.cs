namespace LaMiaPizzeria.Models
{
	public class PizzaCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }

		// Ricorda la lista

		public PizzaCategory()
		{

		}

		public PizzaCategory(string name, string? description)
		{
			Name = name;
			Description = description;
		}

	}
}
