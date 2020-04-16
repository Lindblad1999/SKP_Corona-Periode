using System;

namespace NyeSager
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionPointer.FunctionPointer1 = FunctionPointer.Display;
            FunctionPointer.FunctionPointer2 = FunctionPointer.Display;
            FunctionPointer.FunctionPointer1("Pointer1");
            FunctionPointer.FunctionPointer2("Pointer2", "pointer3");
            Console.ReadKey();

            NumberChanger nc1 = new NumberChanger(Delegate.AddNum);
            NumberChanger nc2 = new NumberChanger(Delegate.MultNum);

            nc1(25);
            Console.WriteLine("Value of Num: {0}", Delegate.getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", Delegate.getNum());
            Console.ReadKey();
        }
    }
}
