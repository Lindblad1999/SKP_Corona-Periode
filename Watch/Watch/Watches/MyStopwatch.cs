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
        private Stopwatch stopWatch = new Stopwatch();
        private string startTime = string.Empty;
        private ListBox lb;

        public MyStopwatch()
        {
            this.timer = new DispatcherTimer();
        }

        /// <summary>
        /// This method will reset everything on the Stopwatch page
        /// </summary>
        public override void Reset()
        {
            stopWatch.Reset(); ///Stops and resets the stopwatch.
            tb.Text = "00:00:00:00"; ///Sets the displayed time back to 0.
            lb.Items.Clear();
        }

        /// <summary>
        /// This method is called when the "Start" button is pressed.
        /// It Starts the stopwatch.
        /// </summary>
        /// <param name="tb">The textBlock where the current time is shown</param>
        public override void Start(TextBlock tb)
        {
            ///Checks if the stopwatch is running
            if (!stopWatch.IsRunning)
            {
                ///A new eventhandler is called that runs every tick.
                timer.Tick += new EventHandler(dispatchStopwatch_Tick);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                this.tb = tb;

                ///The stopwatch starts, and so does the DispatcherTimer
                stopWatch.Start();
                timer.Start();
            }
        }

        /// <summary>
        /// This is the Eventhandler that runs every tick, it changes the textBlock to display the currently elapsed time
        /// </summary>
        void dispatchStopwatch_Tick(object sender, EventArgs e)
        {
            ///Checks if the stopwatch is running, if so it executes the code.
            if (stopWatch.IsRunning)
            {
                ///Creates a TimeSpan with the currently elapsed time, of the stopwatch.
                ///A string is then formatted to look nice, and content of the textBlock is sat to the formatted string.
                TimeSpan ts = stopWatch.Elapsed;
                startTime = String.Format("{0:00}:{1:00}:{2:00},{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                tb.Text = startTime;
            }
        }

        /// <summary>
        /// Method is called when "Stop" button is pressed. It stops the stopwatch.
        /// </summary>
        public override void Stop() => stopWatch.Stop(); ///Pauses the stopwatch.

        /// <summary>
        /// Method is called when the "Lap" button is pressed. It adds the currently elapsed time to the listBox, and keeps running.
        /// </summary>
        public void Lap(ListBox lb)
        {
            this.lb = lb;
            lb.Items.Add(String.Format("{0:00}:{1:00}:{2:00},{3:00}",
                stopWatch.Elapsed.Hours, stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds));
        }
    }
}
