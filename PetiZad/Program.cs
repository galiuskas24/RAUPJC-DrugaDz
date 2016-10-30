using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CetvrtiZad;

namespace PetiZad
{
    class Program
    {
        private static void Main(string[] args)
        {

            var universities = GetAllCroatianUniversities();

            var allCroatianStudents = universities.SelectMany(b => b.Students).Distinct().ToArray();

            var croatianStudentsOnMultipleUniversities = universities.SelectMany(b => b.Students)
                .GroupBy(s => s)
                .Where(a => a.Count() > 1)
                .Select(a => a.Key)
                .ToArray();

            var studentsOnMaleOnlyUniversities = universities.Where(u => u.Students.All(s => s.Gender != Gender.Female))
                .SelectMany(b => b.Students)
                .Distinct()
                .ToArray();

            Console.Out.WriteLine("All Croatian students :");
            PrintStudents(allCroatianStudents);
            
            Console.Out.WriteLine("Croatian students on multiple universities :");
            PrintStudents(croatianStudentsOnMultipleUniversities);
            
            Console.Out.WriteLine("Students on male only universities :");
            PrintStudents(studentsOnMaleOnlyUniversities);

            Console.ReadLine();
        }

        private static void PrintStudents( Student[] students)
        {
            foreach(var student in students)
                if ((bool)(student != null))
                    Console.Out.WriteLineAsync(student.ToString());

            Console.Out.WriteLine();

        }

        private static IEnumerable<University> GetAllCroatianUniversities()
        {
            var zagreb = new University { Name = "Zagreb" };
            var split = new University { Name = "Split" };
            var varazdin = new University { Name = "Varazdin" };
            

            var ante = new Student("Ante", "101", Gender.Male);
            var marko = new Student("Joža", "102", Gender.Male);
            var sanja = new Student("Mirko", "103", Gender.Female);
            var ivana = new Student("Ana", "104", Gender.Female);
            var josipa = new Student("Josipa", "105", Gender.Female);
            var tin = new Student("Tin", "106", Gender.Male);

            zagreb.Students = new[] { ante, sanja, ivana };
            split.Students = new[] { marko, tin };
            varazdin.Students = new[] { josipa, ivana };

            return new[] { zagreb, split, varazdin };
        }
    }
}
