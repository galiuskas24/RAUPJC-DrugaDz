using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListAndEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> list = new GenericList<string>();
            list.Add("First");
            list.Add("Second");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            foreach (var item in list)
            {
                Console.WriteLine(list.IndexOf(item));
            }
            Console.ReadLine();
        }
    }
}
