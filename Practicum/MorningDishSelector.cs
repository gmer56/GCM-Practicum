namespace Practicum
{
	public class MorningDishSelector : IDishSelector
	{
		public string GetDish(DishType dish)
		{
			switch (dish)
			{
				case DishType.Entree:
					return "eggs";
				case DishType.Side:
					return "toast";
				case DishType.Drink:
					return "coffee";
				default:
					throw new InvalidEntryException();
			}
		}
	}
}
