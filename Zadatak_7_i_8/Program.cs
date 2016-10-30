using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadatak_7_i_8
{
    class Program
    {
        static void Main(string[] args)
        {
           var i = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        //we need to add async and await (in function) too all functions

        private static async void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await Sedmi.FactorialDigitSum(n);
            // return for 10! = 27 and for 5! = 3
        }

    }
}
