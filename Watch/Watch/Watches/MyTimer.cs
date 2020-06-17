
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Watch.Watches
{
    public class MyTimer : Watch
    {
        private TextBlock tb;
        private Dispatcher dispatcher;
        private DispatcherTimer timer;
        private TimeSpan targetTime;
        private Stopwatch stopwatch;

        public TimeSpan TargetTime
        {
            get => this.targetTime;
            set 
            {
                ///checks if the addition or reduction made will bring the targettime under 0, or over 24, if not it
                ///allows it to happen
                if (value.Hours >= 0 && value.Minutes >= 0 && value.Seconds >= 0 && value.Days <= 0)
                    this.targetTime = value;
            }
        }

        public MyTimer(Dispatcher dispatcher, TextBlock tb)
        {
            this.dispatcher = dispatcher;
            this.tb = tb;
            targetTime = new TimeSpan(0, 0, 0);
            stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Stops and clears the elapsed time in the stopwatch, and sets the targettime back to zer
        /// </summary>
        public override void Reset()
        {
            stopwatch.Restart();
            targetTime = new TimeSpan(0, 0, 0);
        }
        /// <summary>
        /// Starts the stopwatch, and creates a new DispatcherTimer, for handling the countdown update.
        /// </summary>
        /// <param name="tb"></param>
        public override void Start(TextBlock tb)
        {
            stopwatch.Start();
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
              {
                  UpdateTextBlock();
              }, dispatcher);

            timer.Tick += new EventHandler(timer_Tick);
        }
        /// <summary>
        /// EventHandler that gets called every tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            ///Checks if the stopwatch has reached the targetTime, if so it stops and clears the elapsed time on the stopwatch
            if (TargetTime <= stopwatch.Elapsed)
            {
                stopwatch.Reset();
                targetTime = new TimeSpan(0, 0, 0);
                UpdateTextBlock();
            }
        }
        /// <summary>
        /// Pauses the stopwatch
        /// </summary>
        public override void Stop()
        {
            stopwatch.Stop();
        }
        /// <summary>
        /// Updates the the content of the textBlock, to the current time left on the timer 
        /// </summary>
        private void UpdateTextBlock()
        {
            TimeSpan tempTimeSpan = TargetTime - stopwatch.Elapsed;
            tb.Text = String.Format("{0:00}:{1:00}:{2:00}", tempTimeSpan.Hours, tempTimeSpan.Minutes, tempTimeSpan.Seconds);
        }
        /// <summary>
        /// These three Alter methods takes in a parameter of time, and adds that to the target time
        /// </summary>
        public void AlterHours(int hours) { TargetTime = TargetTime.Add(new TimeSpan(hours, 0, 0)); UpdateTextBlock(); }
        public void AlterMinutes(int minutes) { TargetTime = TargetTime.Add(new TimeSpan(0, minutes, 0)); UpdateTextBlock(); }
        public void AlterSeconds(int seconds) { TargetTime = TargetTime.Add(new TimeSpan(0, 0, seconds)); UpdateTextBlock(); }
    }
}
