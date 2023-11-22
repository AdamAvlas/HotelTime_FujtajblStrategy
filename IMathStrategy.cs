using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujtajblStrategy
{
	public interface IMathStrategy
	{
		string Name { get; }

		public int Calculate(int[] values);
	}
	public class Addition : IMathStrategy
	{
		string IMathStrategy.Name { get { return "Sčítání [a + b]"; } }

		public int Calculate(int[] values)
		{
			int result = 0;
			foreach (int value in values)
			{
				result += value;
			}
			return result;
		}
	}
	public class Subtraction : IMathStrategy
	{
		string IMathStrategy.Name { get { return "Odčítání [a - b]"; } }
		public int Calculate(int[] values)
		{
			int result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
				result -= values[i];
            }
            return result;
		}
	}

	public class Multiplication : IMathStrategy
	{
		string IMathStrategy.Name { get { return "Násobení [a * b]"; } }
		public int Calculate(int[] values)
		{
			int result = values[0];
			for (int i = 1; i < values.Length; i++)
			{
				result = result * values[i];
			}
			return result;
		}
	}
	public class Division : IMathStrategy
	{
		string IMathStrategy.Name { get { return "Dělení [a / b]"; } }
		public int Calculate(int[] values)
		{
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
					Console.WriteLine("Nelze dělit nulou! Vyberte jinou operaci.");
					return 0;
                }
            }
            int result = values[0];
			for (int i = 1; i < values.Length; i++)
			{
				result = result / values[i];
			}
			return result;
		}
	}
}
