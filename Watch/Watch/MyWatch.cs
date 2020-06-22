using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Watch.Watches;

namespace Watch
{
    public class MyWatch
    {
        public MyWatch(Dispatcher dispatcher, TextBlock timerTextBlock, ListBox timerListBox)
        {
            myTimer = new MyTimer(dispatcher, timerTextBlock, timerListBox);
        }

        public MyTimer myTimer;
        public MyStopwatch myStopwatch = new MyStopwatch();
    }
}
