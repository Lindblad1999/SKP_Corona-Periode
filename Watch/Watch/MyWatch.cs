using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watch.Watches;

namespace Watch
{
    public class MyWatch
    {
        public MyTimer myTimer = new MyTimer();
        public MyStopwatch myStopwatch = new MyStopwatch();

        public MyWatch() { }
    }
}
