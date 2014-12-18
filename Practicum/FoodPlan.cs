using System;

namespace Practicum
{
	enum Dish
	{
		
	}
	public class FoodPlan
	{
		public int EntreeCount { get; set; }
		public int SideCount { get; set; }
		public int DrinkCount { get; set; }
		public int DessertCount { get; set; }

		private readonly IDishSelector _selector;
		private readonly IFoodPlanValidator _validator;
		private bool _invalidDish;
		private bool _invalidPlan;

		public FoodPlan(FoodPlanType type)
		{
			switch (type)
			{
				case FoodPlanType.Morning:
					_selector = new MorningDishSelector();
					_validator = new MorningValidator();
					break;
				case FoodPlanType.Night:
					_selector = new NightDishSelector();
					_validator = new NightValidator();
					break;
				default:
					throw new InvalidEntryException();
			}
		}

		public void AddItem(DishType dishType)
		{

			switch (dishType)
			{
				case DishType.Entree:
					EntreeCount++;
					break;
				case DishType.Side:
					SideCount++;
					break;
				case DishType.Drink:
					DrinkCount++;
					break;
				case DishType.Dessert:
					DessertCount++;
					break;
				default:
					_invalidDish = true;
					throw new InvalidEntryException();
			};
		}

		public void RemoveItem(DishType dishType)
		{
			switch (dishType)
			{
				case DishType.Entree:
					EntreeCount--;
					break;
				case DishType.Side:
					SideCount--;
					break;
				case DishType.Drink:
					DrinkCount--;
					break;
				case DishType.Dessert:
					DessertCount--;
					break;
			};
		}

		public bool Validate(DishType lastDishType)
		{
			if (_validator.Validate(this)) return true;

			_invalidPlan = true;
			return false;
		}

		private string GetEntree()
		{
			return (EntreeCount > 0) ? _selector.GetDish(DishType.Entree) + ", ": "";
		}

		private string GetSides()
		{
			var multiplier = "";
			if (SideCount > 1) multiplier = "(x" + SideCount + ")";
			return (SideCount > 0) ? _selector.GetDish(DishType.Side) + multiplier + ", ": "";
		}

		private string GetDrinks()
		{
			var multiplier = "";
			if (DrinkCount > 1) multiplier = "(x" + DrinkCount + ")";
			return (DrinkCount > 0) ? _selector.GetDish(DishType.Drink) + multiplier + ", " : "";
		}

		private string GetDessert()
		{
			return (DessertCount > 0) ?_selector.GetDish(DishType.Dessert) + ", " : "";
		}

		public string GetPlan()
		{
			var errorItem = "";
			if (_invalidDish || _invalidPlan || !_validator.Validate(this)) errorItem = "error";

			var planOutput = GetEntree() + GetSides() + GetDrinks() + GetDessert() + errorItem;

			return planOutput.EndsWith(", ") ? planOutput.Substring(0, planOutput.Length - 2) : planOutput;
		}
	}
}
