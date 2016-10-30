using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetvrtiZad
{
    public class Student
    {

        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public Student(string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }



        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            var stud = obj as Student;
            if ((bool)(stud == null)) return false;
            // compare stud.jmbag and this.jmbag
            return stud.Jmbag.Equals(Jmbag);
        }

        //override because (s == ivan)
        public static object operator ==(Student a, Student b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }


        public static object operator !=(Student a, Student b)
        {
            return !Equals(a, b);
        }


        public override string ToString()
        {
            return $" {Jmbag} - {Name} ({Gender})";
        }

    }

    public enum Gender
    {
        Male,
        Female
    }



}
