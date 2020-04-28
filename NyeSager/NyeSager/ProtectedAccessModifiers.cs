using System;
using System.Collections.Generic;
using System.Text;

namespace NyeSager
{
    class ProtectedAccessModifiers  {    }

    class X
    {
        protected int x;

        public X()
        {
            x = 10;
        }
    }

    class Y : X
    {
        // Members of Y can access 'x' 
        public int getX()
        {
            return x;
        }
    }
}
