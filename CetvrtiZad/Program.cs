using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetvrtiZad
{
    class Program
    {
       
        private static void Main(string[] args)
        {

            AnyStudent(); 
            DoubleStudent();

            Console.ReadLine();
        }

        private static void AnyStudent()
        {
            var list = new List<Student>
            {
                new Student("Ivan", jmbag:"001234567")
            };
            var ivan = new Student("Ivan", jmbag:"001234567");

            bool anyIvanExists = list.Any(s => (bool)(s == ivan));

            Console.Out.WriteLine("anyIvanExist = " + anyIvanExists);
        }

        private static void DoubleStudent()
        {
            var list = new List<Student>
            {
                new Student("Ivan", "001234567"),
                new Student("Ivan", "001234567"),
            };

            var distinctStudents = list.Distinct().Count();
            Console.Out.WriteLine("distinctStudents = " + distinctStudents);
        }
    }
}

