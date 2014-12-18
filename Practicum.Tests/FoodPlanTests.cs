using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practicum.Tests
{
	[TestClass]
	public class FoodPlanTests
	{
	
		[TestMethod]
		public void ConstructrWithMorningPlanType()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
		}
	

		[TestMethod]
		public void ConstructrWithNightPlanType()
		{
			var temp = new FoodPlan(FoodPlanType.Night);
		}
		
		[TestMethod]
		[ExpectedException(typeof(InvalidEntryException))]
		public void AddInvalidDishShouldThrowException()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem((DishType)7);
		}

		[TestMethod]
		public void AddDishShouldAddEntreeToProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Entree);

			Assert.AreEqual(1, temp.EntreeCount);
		}

		[TestMethod]
		public void AddDishShouldAddSideToProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Side);

			Assert.AreEqual(1, temp.SideCount);
		}

		[TestMethod]
		public void AddDishShouldAddDrinkToProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Drink);

			Assert.AreEqual(1, temp.DrinkCount);
		}

		[TestMethod]
		public void AddDishShouldAddDessertToProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Dessert);

			Assert.AreEqual(1, temp.DessertCount);
		}

		[TestMethod]
		public void RemoveDishShouldRemoveEntreeFromProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Entree);
			Assert.AreEqual(1, temp.EntreeCount);
			temp.RemoveItem(DishType.Entree);
			Assert.AreEqual(0, temp.EntreeCount);
		}

		[TestMethod]
		public void RemoveDishShouldRemoveSideFromProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Side);
			Assert.AreEqual(1, temp.SideCount);
			temp.RemoveItem(DishType.Side);
			Assert.AreEqual(0, temp.SideCount);
			
		}

		[TestMethod]
		public void RemoveDishShouldRemoveDrinkFromProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Drink);
			Assert.AreEqual(1, temp.DrinkCount);

			temp.RemoveItem(DishType.Drink);
			Assert.AreEqual(0, temp.DrinkCount);
			
		}

		[TestMethod]
		public void RemoveDishShouldRemoveDessertFromProperBucket()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Dessert);
			Assert.AreEqual(1, temp.DessertCount);
			temp.RemoveItem(DishType.Dessert);
			Assert.AreEqual(0, temp.DessertCount);
			
		}

		[TestMethod]
		public void MorningPlanShouldNotAllowMoreThanOneEntree()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Entree);
			temp.AddItem(DishType.Entree);
			var isValid = temp.Validate(DishType.Entree);

			Assert.AreEqual(false, isValid);
		}

		[TestMethod]
		public void MorningPlanShouldNotAllowMoreThanOneSide()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Side);
			temp.AddItem(DishType.Side);
			var isValid = temp.Validate(DishType.Side);

			Assert.AreEqual(false, isValid);
		}

		[TestMethod]
		public void MorningPlanShouldAllowMoreThanOneDrink()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Drink);
			temp.AddItem(DishType.Drink);
			var isValid = temp.Validate(DishType.Drink);

			Assert.AreEqual(2, temp.DrinkCount);
			Assert.AreEqual(true, isValid);
		}

		[TestMethod]
		public void MorningPlanShouldNotAllowDessert()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Dessert);
			var isValid = temp.Validate(DishType.Dessert);

			Assert.AreEqual(false, isValid);
		}

		[TestMethod]
		public void NightPlanShouldNotAllowMoreThanOneEntree()
		{
			var temp = new FoodPlan(FoodPlanType.Night);
			temp.AddItem(DishType.Entree);
			temp.AddItem(DishType.Entree);
			var isValid = temp.Validate(DishType.Entree);

			Assert.AreEqual(false, isValid);
		}

		[TestMethod]
		public void NightPlanShouldAllowMoreThanOneSide()
		{
			var temp = new FoodPlan(FoodPlanType.Night);
			temp.AddItem(DishType.Side);
			temp.AddItem(DishType.Side);
			var isValid = temp.Validate(DishType.Side);

			Assert.AreEqual(2, temp.SideCount);
			Assert.AreEqual(true, isValid);
		}

		[TestMethod]
		public void NightPlanShouldNotAllowMoreThanOneDrink()
		{
			var temp = new FoodPlan(FoodPlanType.Night);
			temp.AddItem(DishType.Drink);
			temp.AddItem(DishType.Drink);
			var isValid = temp.Validate(DishType.Drink);

			Assert.AreEqual(false, isValid);
		}

		[TestMethod]
		public void NightPlanShouldNotAllowMoreThanOneDessert()
		{
			var temp = new FoodPlan(FoodPlanType.Night);
			temp.AddItem(DishType.Dessert);
			temp.AddItem(DishType.Dessert);
			var isValid = temp.Validate(DishType.Dessert);

			Assert.AreEqual(false, isValid);
		}

		[TestMethod]
		public void GetPlansReturnsErrorWhenNoDishesAreAdded()
		{
			var temp = new FoodPlan(FoodPlanType.Night);
			var result = temp.GetPlan();
			Assert.AreEqual("error", result);
		}

		[TestMethod]
		public void GetPlansReturnMultipleSides()
		{
			var temp = new FoodPlan(FoodPlanType.Night);
			temp.AddItem(DishType.Side);
			temp.AddItem(DishType.Side);
			var result = temp.GetPlan();
			StringAssert.Contains(result,"x2");
		}

		[TestMethod]
		public void GetPlansReturnMultipleDrinks()
		{
			var temp = new FoodPlan(FoodPlanType.Morning);
			temp.AddItem(DishType.Drink);
			temp.AddItem(DishType.Drink);
			temp.AddItem(DishType.Drink);
			var result = temp.GetPlan();
			StringAssert.Contains(result, "x3");
		}

	}
}
