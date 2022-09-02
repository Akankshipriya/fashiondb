using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace reftype
{
    public class Student
    {

        public string StudentName { get; set; }

    }

    class Program
    {
        //value type
        static void ChangeValue(int x)
        {
            x = 200;
            Console.WriteLine(x);
        }

        //reference type
        public static void ChangeReferenceType(Student std2)
        {
            std2.StudentName = "Akankshi";
        }
        static void Main(string[] args)
        {
            // value type
            int i = 100;
            Console.WriteLine(i);
            ChangeValue(i);
            Console.WriteLine(i);

            //reference type
            Student std1 = new Student();
            std1.StudentName = "Priya";
            ChangeReferenceType(std1);
            Console.WriteLine(std1.StudentName);
            Console.ReadLine();

        }
    }
}
