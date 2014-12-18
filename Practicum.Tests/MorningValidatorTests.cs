using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practicum.Tests
{
	[TestClass]
	public class MorningValidatorTests : BaseValidatorTests
	{
		[TestMethod]
		public void FoodPlanWithDessertShouldBeInvalid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Dessert);
			var val = new MorningValidator();

			var isValid = val.Validate(fp);

			Assert.IsFalse(isValid);
		}

		[TestMethod]
		public void FoodPlanWithoutDessertShouldBeValid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Drink);
			fp.AddItem(DishType.Side);
			var val = new MorningValidator();

			var isValid = val.Validate(fp);

			Assert.IsTrue(isValid);
		}

		[TestMethod]
		public void FoodPlanWithMoreThanOneSideShouldBeInvalid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Side);
			fp.AddItem(DishType.Side);
			var val = new MorningValidator();

			var isValid = val.Validate(fp);

			Assert.IsFalse(isValid);
		}

		[TestMethod]
		public void FoodPlanWithOneDrinkShouldBeValid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Drink);
			var val = new MorningValidator();

			var isValid = val.Validate(fp);

			Assert.IsTrue(isValid);
		}

		[TestMethod]
		public void FoodPlanWithMoreThanOneDrinkShouldBeValid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Drink);
			fp.AddItem(DishType.Drink);
			var val = new MorningValidator();

			var isValid = val.Validate(fp);

			Assert.IsTrue(isValid);
		}
	}
}
