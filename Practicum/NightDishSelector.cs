namespace Practicum
{
	public class NightDishSelector : IDishSelector
	{
		public string GetDish(DishType dish)
		{
			switch (dish)
			{
				case DishType.Entree:
					return "steak";
				case DishType.Side:
					return "potato";
				case DishType.Drink:
					return "wine";
				case DishType.Dessert:
					return "cake";
				default:
					throw new InvalidEntryException();
			}
		}
	}
}
