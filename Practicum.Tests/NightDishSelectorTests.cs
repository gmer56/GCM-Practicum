using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practicum.Tests
{
	[TestClass]
	public class NightDishSelectorTests
	{
		[TestMethod]
		public void ShouldReturnCorrectEntree()
		{
			var temp = new NightDishSelector();
			var dish = temp.GetDish(DishType.Entree);

			Assert.AreEqual("steak", dish);
		}

		[TestMethod]
		public void ShouldReturnCorrectSide()
		{
			var temp = new NightDishSelector();
			var dish = temp.GetDish(DishType.Side);

			Assert.AreEqual("potato", dish);
		}

		[TestMethod]
		public void ShouldReturnCorrectDrink()
		{
			var temp = new NightDishSelector();
			var dish = temp.GetDish(DishType.Drink);

			Assert.AreEqual("wine", dish);
		}
		[TestMethod]
		public void ShouldReturnCorrectDessert()
		{
			var temp = new NightDishSelector();
			var dish = temp.GetDish(DishType.Dessert);

			Assert.AreEqual("cake", dish);
		}
	}
}
