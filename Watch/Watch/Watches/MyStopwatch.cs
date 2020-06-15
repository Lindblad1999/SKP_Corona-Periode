using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Watch.Watches
{
    public class MyStopwatch : Watch
    {

        private DispatcherTimer dispatchStopwatch = new DispatcherTimer();
        private Stopwatch stopWatch = new Stopwatch();
        private string startTime = string.Empty;
        private TextBlock tb;


        public override void Reset()
        {
            stopWatch.Reset();
            tb.Text = "00:00:00:00";
        }

        public override void Start(TextBlock tb)
        {
            if (!stopWatch.IsRunning)
            {
                dispatchStopwatch.Tick += new EventHandler(dispatchStopwatch_Tick);
                dispatchStopwatch.Interval = new TimeSpan(0, 0, 0, 0, 1);
                this.tb = tb;

                stopWatch.Start();
                dispatchStopwatch.Start();
            }
        }

        void dispatchStopwatch_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                startTime = String.Format("{0:00}:{1:00}:{2:00},{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                tb.Text = startTime;
            }
        }

        public override void Stop()
        {
            stopWatch.Stop();
        }
    }
}
