using System;

namespace ConsoleApp1
{
    class Program
    {
        //define delegate
        //public delegate void addDelegate(int a, int b);
        //public delegate string greetingDelegate(string name);
        //public void add(int x,int y)
        //{
        //    Console.WriteLine(@"the sum of {0} and {1} is {2}", x, y, (x + y));
        //}
        //public static string greetings(string name)
        //{
        //    return "hello" + name;
        //}

        //----------------generic delegate-----------------------

        //define delegate
        //func generic delegate
        //public delegate double addnumber1delegate(int no1, float no2, double no3);
        //action generic
        //public delegate void addnumber2delegate(int no1, float no2, double no3);
        //predicate generic
        //public delegate bool checklengthdelegate(string name);

        //returning function
        public static double addnumber1(int no1, float no2, double no3)
        {
            return no1 + no2 + no3;
        }
        //printing function
        public static void addnumber2(int no1, float no2, double no3)
        {
            Console.WriteLine(no1 + no2 + no3);
        }
        //conditional returning function
        public static bool checklength(string name)
        {
            if (name.Length > 5)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            //Program obj = new Program();
            //obj.add(20, 30);
            //string msg = Program.greetings("anjali");
            //Console.WriteLine(msg);

            //instantiating delegate
            //addDelegate ad = new addDelegate(obj.add);
            //greetingDelegate gd = new greetingDelegate(Program.greetings);

            //invoke delegates
            //ad(100, 200);
            //string s=gd("anjali");
            //Console.WriteLine(s);

            //addnumber1delegate obj1 = new addnumber1delegate(addnumber1);
            //double result = obj1.Invoke(12, 125.25f, 91.92);
            //Console.WriteLine(result);

            //addnumber2delegate obj2 = new addnumber2delegate(addnumber2);
            //obj2.Invoke(10, 12.5f, 76.08);

            //checklengthdelegate obj3 = new checklengthdelegate(checklength);
            //bool status = obj3.Invoke("mayank");
            //Console.WriteLine(status);

            //--------------generic delegate--------------------//

            Func<int, float, double, double> obj1 = new Func<int, float, double, double>(addnumber1);
            double result = obj1.Invoke(5, 85.6f, 23.80);
            Console.WriteLine(result);

            Action<int, float, double> obj2 = new Action<int, float, double>(addnumber2);
            obj2.Invoke(45, 78.9f, 98.34);

            Predicate<string> obj3 = new Predicate<string>(checklength);
            bool status = obj3.Invoke("mayank");
            Console.WriteLine(status);
        }
    }
}