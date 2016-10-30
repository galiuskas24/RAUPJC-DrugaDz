using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_7_i_8
{
    class Sedmi
    {

         internal static async Task<int> FactorialDigitSum(int n)
        {
            int temp = await Task.Run(() => Factorial(n));
            return await Task.Run(() => SumOfDigits(temp));
        }

        private static int Factorial(int n)
        {
            int fact = 1;

            for (int i = 2; i <= n; i++)
                fact *= i;

            return fact;
        }

        private static int SumOfDigits(int num)
        {
            int sum = 0;
            var array = num.ToString().ToCharArray();

            foreach (var s in array)
                sum += s - '0';

            return sum;
        }
    }
}
