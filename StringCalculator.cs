using System;
using System.Linq;

namespace stringcalculator
{
    public class StringCalculator
    {
        public double calculator;

        public StringCalculator()
        {
            //Calculator = 0;
        }

        public StringCalculator(double calculator) 
        {
            this.calculator = calculator;
        }

        public double Calculator
        {
            get { return calculator; } 
        }
        
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                calculator = 0;
                return 0;
            }

            var delimiters = new[] { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                var delimiterDefinition = numbers.Substring(2, numbers.IndexOf('\n') - 2);
                delimiters = new[] { delimiterDefinition };
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);
            }

            var numberStrings = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var negatives = numberStrings.Where(x => int.Parse(x) < 0);
            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(",", negatives)}");
            }

            var sum = numberStrings.Where(x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
            calculator += sum;
            return sum;
        }
    }
}
