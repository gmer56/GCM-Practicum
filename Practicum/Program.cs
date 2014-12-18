using System;
using System.Linq;

namespace Practicum
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Input: (Type 'Exit' to quit)");
			var input = Console.ReadLine();

			while (input != null && input.ToLower() != "exit")
			{
				var inputs = input.Split(',');
				var output = "Output: ";

				try
				{
					if (inputs.Length == 0) throw new InvalidEntryException();
					FoodPlanType planType = GetFoodPlanType(inputs[0]);
					
					var fp = new FoodPlan(planType);
					var keepProcessing = true;
					for (var index = 1; keepProcessing &&  index < inputs.Count(); index++)
					{
						try
						{
							var dishType = (DishType) int.Parse(inputs[index]);
							fp.AddItem(dishType);
							keepProcessing = fp.Validate(dishType);

							//invalid plan remove last added dish
							if (!keepProcessing) fp.RemoveItem(dishType);
						}
						catch (FormatException fe)
						{
							keepProcessing = false;
						}
						catch (InvalidEntryException iee)
						{
							keepProcessing = false;
						}
					}

					output += fp.GetPlan();
				}
				catch (InvalidEntryException ex)
				{
					output += "error";
				}
				finally
				{
					Console.WriteLine(output);
					Console.WriteLine();
					Console.Write("Input: (Type 'Exit' to quit)");
					input = Console.ReadLine();
				}
			}
		
		}

		public static FoodPlanType GetFoodPlanType(string planTypeInput)
		{
			planTypeInput = planTypeInput.ToLower();

			switch (planTypeInput)
			{
				case "morning":
					return FoodPlanType.Morning;
				case "night":
					return FoodPlanType.Night;
				default:
					throw new InvalidEntryException();
			}
		}
	}
}
