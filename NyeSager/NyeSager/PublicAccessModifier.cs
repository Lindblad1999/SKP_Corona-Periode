using System;
using System.Collections.Generic;
using System.Text;

namespace NyeSager
{
    class PublicAccessModifier
    {
        public int rollNo;
        public string name;

        public PublicAccessModifier(int r, string n)
        {
            rollNo = r;
            name = n;
        }

        public int getRollNo()
        {
            return rollNo;
        }

        public string GetName()
        {
            return name;
        }
    }
}
