namespace Practicum
{
	public class BaseValidator 
	{
		public bool Validate(FoodPlan plan)
		{
			if (plan.EntreeCount == 0 && plan.SideCount == 0 && plan.DrinkCount == 0 && plan.DessertCount == 0) return false;
			if (plan.EntreeCount > 1) return false;

			return true;
		}
	}
	
}
