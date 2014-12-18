using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practicum.Tests
{
	[TestClass]
	public class NightValidatorTests : BaseValidatorTests
	{
		[TestMethod]
		public void FoodPlanWithMoreThanOneDessertShouldBeInvalid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Dessert);
			fp.AddItem(DishType.Dessert);
			var val = new NightValidator();

			var isValid = val.Validate(fp);

			Assert.IsFalse(isValid);
		}

		[TestMethod]
		public void FoodPlanWithOneDessertShouldBevalid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Dessert);
			var val = new NightValidator();

			var isValid = val.Validate(fp);

			Assert.IsTrue(isValid);
		}

		[TestMethod]
		public void FoodPlanWithMoreThanOneDrinkShouldBeInvalid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Drink);
			fp.AddItem(DishType.Drink);
			var val = new NightValidator();

			var isValid = val.Validate(fp);

			Assert.IsFalse(isValid);
		}

		[TestMethod]
		public void FoodPlanWithOneDrinkShouldBeValid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Drink);
			var val = new NightValidator();

			var isValid = val.Validate(fp);

			Assert.IsTrue(isValid);
		}


		[TestMethod]
		public void FoodPlanWithMoreThanOneSideShouldBeValid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Side);
			fp.AddItem(DishType.Side);
			var val = new NightValidator();

			var isValid = val.Validate(fp);

			Assert.IsTrue(isValid);
		}
	}
}
