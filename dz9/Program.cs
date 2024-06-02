using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int> { -1, -2, -5, 0 };

            try
            {
                double average = CalculateAverageOfPositiveNumbers(num);
                Console.WriteLine("Среднее арифмитическое положительных чисел: " + average);
            }
            catch (NoPositiveNumbersException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }

        public static double CalculateAverageOfPositiveNumbers(List<int> num) 
        {
            var positiveNum = num.Where(n => n > 0);

            if(!positiveNum.Any())
            {
                throw new NoPositiveNumbersException();
            }
            return positiveNum.Average();
        }
    }

    public class NoPositiveNumbersException : Exception
    {
        public NoPositiveNumbersException() : base("Нет позитивного числа.")
        {

        }
    }
}
