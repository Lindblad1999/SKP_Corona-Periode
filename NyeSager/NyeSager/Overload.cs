using System;
using System.Collections.Generic;
using System.Text;

namespace NyeSager
{
    public static class Overload
    {
        public static void met1(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("This is the first method");
        }

        public static void met1(string message, int num)
        {
            Console.WriteLine(message + num);
            Console.WriteLine("This is the first method overload");
        }

        public static void met1(string message, int num, double num2)
        {
            Console.WriteLine(message + num + num2);
            Console.WriteLine("This is the second method overload");
        }

        public static void Call()
        {
            met1("Hi");
            met1("Hi", 5);
            met1("Hi", 5, 6.56);
        }
    }
}
