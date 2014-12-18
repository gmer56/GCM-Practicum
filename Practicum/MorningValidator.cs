namespace Practicum
{
	public class MorningValidator : BaseValidator,IFoodPlanValidator
	{
		public new bool Validate(FoodPlan plan)
		{
			return base.Validate(plan) && ValidateNoDessert(plan) && ValidateSingleSide(plan); 
		}

		private bool ValidateNoDessert(FoodPlan plan)
		{
			return plan.DessertCount == 0;
		}

		private bool ValidateSingleSide(FoodPlan plan)
		{
			return plan.SideCount <= 1;
		}
	}
}
