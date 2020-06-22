
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
using Watch.Interfaces;

namespace Watch.Watches
{
    public class MyTimer : Watch, IAlterTime
    {
        private TextBlock tb;
        private Dispatcher dispatcher;
        private DispatcherTimer timer;
        private TimeSpan targetTime;
        private Stopwatch stopwatch;

        private ComboBox cbHours;
        private ComboBox cbMinutes;
        private ComboBox cbSeconds;

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

        public void AddTime() 
        { 
            TargetTime = TargetTime.Add(new TimeSpan(cbHours.SelectedIndex, cbMinutes.SelectedIndex, cbSeconds.SelectedIndex)); 
            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;
            cbSeconds.SelectedIndex = 0;
            UpdateTextBlock();
        }

        public void SubtractTime()
        {
            TargetTime = TargetTime.Add(new TimeSpan(-cbHours.SelectedIndex, -cbMinutes.SelectedIndex, -cbSeconds.SelectedIndex));
            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;
            cbSeconds.SelectedIndex = 0;
            UpdateTextBlock();
        }

        public void Initialize(ComboBox cbHours, ComboBox cbMinutes, ComboBox cbSeconds)
        {
            this.cbHours = cbHours;
            this.cbMinutes = cbMinutes;
            this.cbSeconds = cbSeconds;

            for (int i = 0; i < 25; i++) { cbHours.Items.Add(i); }
            for (int i = 0; i < 60; i++){ cbMinutes.Items.Add(i); cbSeconds.Items.Add(i); }
            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;
            cbSeconds.SelectedIndex = 0;
        }
    }
}
