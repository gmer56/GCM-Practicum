using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practicum.Tests
{
	[TestClass]
	public class ProgramTests
	{
		[TestMethod]
		public void MorningInputShouldReturnCorrectType()
		{
			var type = Program.GetFoodPlanType("morning");

			Assert.AreEqual(FoodPlanType.Morning,type);
		}

		[TestMethod]
		public void MorningCaseInsensitiveInputShouldReturnCorrectType()
		{
			var type = Program.GetFoodPlanType("MORNING");

			Assert.AreEqual(FoodPlanType.Morning, type);
		}

		[TestMethod]
		public void NightInputShouldReturnCorrectType()
		{
			var type = Program.GetFoodPlanType("night");

			Assert.AreEqual(FoodPlanType.Night, type);
		}

		[TestMethod]
		public void NightCaseInsensitiveInputShouldReturnCorrectType()
		{
			var type = Program.GetFoodPlanType("night");

			Assert.AreEqual(FoodPlanType.Night, type);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidEntryException))]
		public void ShouldThrowExceptionForNonExistentFoodPlanType()
		{
			var type = Program.GetFoodPlanType("junk");
		}
	}
}
