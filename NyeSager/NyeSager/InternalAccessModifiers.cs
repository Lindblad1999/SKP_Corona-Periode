using System;
using System.Collections.Generic;
using System.Text;

namespace NyeSager
{
    class InternalAccessModifiers
    {
        Complex c = new Complex();

        void ok()
        {
            c.setData(2,1);
            c.displayData();
        }
    }

    internal class Complex
    {
        
        int real;
        int img;

        public void setData(int r, int i)
        {
            real = r;
            img = i;
        }

        public void displayData()
        {
            Console.WriteLine("Real = {0}", real);
            Console.WriteLine("Imaginary = {0}", img);
        }
    }
}
