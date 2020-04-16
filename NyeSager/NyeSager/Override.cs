using System;
using System.Collections.Generic;
using System.Text;

namespace NyeSager
{
    public abstract class Override
    {
        public abstract void met1();
    }

    public class Override2 : Override
    {
        public override void met1()
        {
            throw new NotImplementedException();
            //Code
        }
    }


    public class Override3
    {
        public virtual void met1()
        {
            Console.WriteLine("Den gør noget");
        }
    }

    public class Override4 : Override3
    {
        public override void met1()
        {
            Console.WriteLine("Nu gør den noget andet");
        }
    }
}
