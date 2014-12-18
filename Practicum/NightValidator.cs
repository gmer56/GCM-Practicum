using System;

namespace Practicum
{
	public class NightValidator : BaseValidator, IFoodPlanValidator
	{
		public new bool Validate(FoodPlan plan)
		{
			return base.Validate(plan) && ValidateSingleDrink(plan) && ValidateSingleDessert(plan);
		}

		private bool ValidateSingleDrink(FoodPlan plan)
		{
			return plan.DrinkCount <= 1;
		}

		private bool ValidateSingleDessert(FoodPlan plan)
		{
			return plan.DessertCount <= 1;
		}
	}
}
