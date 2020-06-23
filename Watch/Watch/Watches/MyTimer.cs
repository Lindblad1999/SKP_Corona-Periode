
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
using Watch.WatchObjects;

namespace Watch.Watches
{
    public class MyTimer : Watch, IAlterTime
    {
        private TextBlock tb;
        private Dispatcher dispatcher;
        private DispatcherTimer timer;

        private ComboBox cbHours;
        private ComboBox cbMinutes;
        private ComboBox cbSeconds;
        private ListBox listBoxTimers;

        private List<Timer> timers;

        private int currentSelection;

        public MyTimer(Dispatcher dispatcher, TextBlock tb, ListBox listBoxTimers)
        {
            this.dispatcher = dispatcher;
            this.tb = tb;
            this.listBoxTimers = listBoxTimers;
            timers = new List<Timer>();
        }

        /// <summary>
        /// Stops and clears the elapsed time in the stopwatch, and sets the targettime back to zer
        /// </summary>
        public override void Reset()
        {
            if (listBoxTimers.SelectedIndex != -1)
            {
                timers[listBoxTimers.SelectedIndex].CurrentTime.Restart();
                timers[listBoxTimers.SelectedIndex].TargetTime = new TimeSpan(0, 0, 0);
            }

            UpdateListBox();
        }

        public void New()
        {
            timers.Add(new Timer());

            UpdateListBox();
        }

        /// <summary>
        /// Starts the stopwatch, and creates a new DispatcherTimer, for handling the countdown update.
        /// </summary>
        /// <param name="tb"></param>
        public override void Start(TextBlock tb)
        {
            if (listBoxTimers.SelectedIndex != -1)
            {
                timers[listBoxTimers.SelectedIndex].CurrentTime.Start();
            }
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
            foreach (Timer timer in timers)
            {
                if (timer.TargetTime <= timer.CurrentTime.Elapsed)
                {
                    timer.CurrentTime.Reset();
                    timer.TargetTime = new TimeSpan(0, 0, 0);
                    UpdateTextBlock();
                }
            }
            UpdateListBox();
        }

        internal void RemoveTimer()
        {
            if (listBoxTimers.SelectedIndex != -1)
            {
                timers.RemoveAt(listBoxTimers.SelectedIndex);
                listBoxTimers.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Pauses the stopwatch
        /// </summary>
        public override void Stop()
        {
            if (listBoxTimers.SelectedIndex != -1)
                timers[listBoxTimers.SelectedIndex].CurrentTime.Stop();
        }

        internal void listBoxTimers_SelectionChanged()
        {
            if (listBoxTimers.SelectedIndex != -1)
                currentSelection = listBoxTimers.SelectedIndex;
            listBoxTimers.SelectedIndex = currentSelection;

        }

        /// <summary>
        /// Updates the the content of the textBlock, to the current time left on the timer 
        /// </summary>
        /// 
        private void UpdateTextBlock()
        {
            if (listBoxTimers.SelectedIndex != -1)
            {
                TimeSpan tempTimeSpan = timers[listBoxTimers.SelectedIndex].TargetTime - timers[listBoxTimers.SelectedIndex].CurrentTime.Elapsed;
                tb.Text = String.Format("{0:00}:{1:00}:{2:00}", tempTimeSpan.Hours, tempTimeSpan.Minutes, tempTimeSpan.Seconds);
            }
        }

        public void AddTime()
        {
            if (listBoxTimers.SelectedIndex != -1)
            {
                timers[listBoxTimers.SelectedIndex].TargetTime = timers[listBoxTimers.SelectedIndex].TargetTime.Add(new TimeSpan(cbHours.SelectedIndex, cbMinutes.SelectedIndex, cbSeconds.SelectedIndex));
                cbHours.SelectedIndex = 0;
                cbMinutes.SelectedIndex = 0;
                cbSeconds.SelectedIndex = 0;
                UpdateTextBlock();
            }
        }

        public void SubtractTime()
        {
            if (listBoxTimers.SelectedIndex != -1)
            {
                timers[listBoxTimers.SelectedIndex].TargetTime = timers[listBoxTimers.SelectedIndex].TargetTime.Add(new TimeSpan(-cbHours.SelectedIndex, -cbMinutes.SelectedIndex, -cbSeconds.SelectedIndex));
                cbHours.SelectedIndex = 0;
                cbMinutes.SelectedIndex = 0;
                cbSeconds.SelectedIndex = 0;
                UpdateTextBlock();
            }
        }

        public void Initialize(ComboBox cbHours, ComboBox cbMinutes, ComboBox cbSeconds)
        {
            this.cbHours = cbHours;
            this.cbMinutes = cbMinutes;
            this.cbSeconds = cbSeconds;

            for (int i = 0; i < 25; i++) { cbHours.Items.Add(i); }
            for (int i = 0; i < 60; i++) { cbMinutes.Items.Add(i); cbSeconds.Items.Add(i); }
            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;
            cbSeconds.SelectedIndex = 0;
        }

        private void UpdateListBox()
        {
            listBoxTimers.Items.Clear();
            foreach (Timer timer in timers)
            {
                listBoxTimers.Items.Add(String.Format("{0:00}:{1:00}:{2:00}", (timer.TargetTime - timer.CurrentTime.Elapsed).Hours,
                    (timer.TargetTime - timer.CurrentTime.Elapsed).Minutes, (timer.TargetTime - timer.CurrentTime.Elapsed).Seconds));
            }
        }
    }
}
