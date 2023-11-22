namespace FujtajblStrategy
{
	internal class Program
	{
		static int InputCheck(string varName)
		{
			while (true)
			{
				Console.Write("Zadejte číslo {0}: ", varName);
				string input = Console.ReadLine();

				if (!String.IsNullOrEmpty(input))
				{
					if (Int32.TryParse(input, out int returnValue))
					{
						return returnValue;
					}
					else
					{
						Console.WriteLine("Zadána neplatná hodnota! Zkuste to prosím znovu.");
					}
				}
				else
				{
					Console.WriteLine("Nebyla zadána hodnota! Zkuste to prosím znovu.");
				}
			}
		}
		public static bool ShouldContinueFunction()
		{
			while (true)
			{
				string repeat = Console.ReadLine();

				if (repeat == "Y" || repeat == "y")
				{
					return true;
				}
				if (repeat == "N" || repeat == "n")
				{
					Console.WriteLine("Ukončování programu...");
					return false;
				}
				else
				{
					Console.WriteLine("Neplatná hodnota. Zkuste znovu.");
				}

			}
		}
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();

				int valueA = InputCheck("A");

				int valueB = InputCheck("B");

				int[] vals = { valueA, valueB };
				Console.Write("Vaše čísla: " + string.Join("; ", vals) + "\n");

                CalculatorContext context = new CalculatorContext(vals);

				Dictionary<string, IMathStrategy> strategies = new Dictionary<string, IMathStrategy>()
				{
					{ "1", new Addition() },
					{ "2", new Subtraction() },
					{ "3", new Multiplication() },
					{ "4", new Division() }
				};

				Console.WriteLine("Vyberte matematickou operaci: ");
				foreach (var item in strategies)
				{
					Console.WriteLine("[{0}] - {1}", item.Key, item.Value.Name);
				}

				int result;
				while (true)
				{
					Console.Write("Výběr: ");
					string operationChoice = Console.ReadLine();

					try
					{
						context.SetStrategy(strategies[operationChoice]);
						result = context.returnValues();
						break;
					}
					catch (Exception e)
					{
						Console.WriteLine("Neplatná/prázdná volba! Zkuste znovu. (" + e.Message + ")");
					}

				}


				Console.WriteLine("Výsledek: " + result);

				Console.Write("Přejete si provést další výpočet? [Y/N]: ");

				if (!ShouldContinueFunction()) break;
			}
		}
	}

	public class CalculatorContext
	{
		IMathStrategy strategy;
		int[] values;

		public CalculatorContext(int[] input)
		{
			this.values = input;
		}

		public void SetStrategy(IMathStrategy strategy)
		{
			this.strategy = strategy;
		}

		public int returnValues()
		{
			return strategy.Calculate(values);
		}
	}
}