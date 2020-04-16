using System;
using System.Collections.Generic;
using System.Text;

namespace NyeSager
{
    public static class FunctionPointer
    {
        public static Func<string, string> FunctionPointer1 = null;
        public static Func<string, string, string> FunctionPointer2 = null;

        public static string Display(string message)
        {
            Console.WriteLine(message);
            return "Hello";
        }

        public static string Display(string message1, string message2)
        {
            Console.WriteLine(message1);
            Console.WriteLine(message2);
            return null;
        }
    }
}
