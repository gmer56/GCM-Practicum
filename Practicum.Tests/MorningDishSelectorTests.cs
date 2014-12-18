using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practicum.Tests
{
	[TestClass]
	public class MorningDishSelectorTests
	{
		[TestMethod]
		public void ShouldReturnCorrectEntree()
		{
			var temp = new MorningDishSelector();
			var dish = temp.GetDish(DishType.Entree);

			Assert.AreEqual("eggs", dish);
		}

		[TestMethod]
		public void ShouldReturnCorrectSide()
		{
			var temp = new MorningDishSelector();
			var dish = temp.GetDish(DishType.Side);

			Assert.AreEqual("toast",dish);
		}

		[TestMethod]
		public void ShouldReturnCorrectDrink()
		{
			var temp = new MorningDishSelector();
			var dish = temp.GetDish(DishType.Drink);

			Assert.AreEqual("coffee", dish);
		}
		[TestMethod]
		[ExpectedException(typeof(InvalidEntryException))]
		public void ShouldThrowExceptionForDessert()
		{
			var temp = new MorningDishSelector();
			temp.GetDish(DishType.Dessert);
		}
	}
}
