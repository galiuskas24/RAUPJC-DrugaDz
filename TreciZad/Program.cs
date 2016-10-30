using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreciZad
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };

            var array = integers.GroupBy(x => x).Distinct().ToArray();

            var strings = new string[array.Length];

            foreach (var i in array)
            {
                // i.Key starts with 1
                strings[i.Key-1] = $"Broj {i.Key} se pojavljuje {i.Count()} puta. ";
                Console.Out.WriteLine("strings["+ (i.Key-1) + "] = " + strings[i.Key-1]);
            }
            Console.ReadLine();
        }
    }
}
