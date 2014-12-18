using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Practicum.Tests
{
	[TestClass]
	public class BaseValidatorTests
	{
		protected FoodPlan SetupValidBaseFoodPlan()
		{
			var fp = new FoodPlan(FoodPlanType.Morning);
			fp.AddItem(DishType.Entree);
			return fp;
		}

		[TestMethod]
		public void FoodPlanWithNoDishesShouldBeInvalid()
		{
			var fp = new FoodPlan(FoodPlanType.Morning);
			var val = new BaseValidator();

			var isValid = val.Validate(fp);

			Assert.IsFalse(isValid);
		}

		[TestMethod]
		public void FoodPlanWithMoreThanOneentreeShouldBeInvalid()
		{
			var fp = SetupValidBaseFoodPlan();
			fp.AddItem(DishType.Entree);
			fp.AddItem(DishType.Entree);
			var val = new BaseValidator();

			var isValid = val.Validate(fp);

			Assert.IsFalse(isValid);
		}
	}
}
