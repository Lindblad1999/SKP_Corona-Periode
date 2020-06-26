
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Watch.Interfaces;
using Watch.WatchObjects;

namespace Watch.Watches
{
    public class MyTimer : Watch, IAlterTime, IUpdate
    {
        private Dispatcher dispatcher;

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
        /// Method is called when the "Reset" button has been pressed.
        /// Stops and clears the elapsed time in the stopwatch, and sets the targettime back to zero.
        /// </summary>
        public override void Reset()
        {
            ///Checks if the listBox is empty, by checking if the selected index = -1, to avoid an exception being thrown.
            if (listBoxTimers.SelectedIndex != -1)
            {
                timers[listBoxTimers.SelectedIndex].CurrentTime.Restart();
                timers[listBoxTimers.SelectedIndex].TargetTime = new TimeSpan(0, 0, 0);
            }

            UpdateListBox();
        }

        /// <summary>
        /// Method is called when the "Create New" Button has been clicked.
        /// It creates a new instance of Timer, and adds it to the timers List
        /// </summary>
        public void New()
        {
            timers.Add(new Timer());

            UpdateListBox();
        }

        /// <summary>
        /// Method is called when the "Start" button has been pressed.
        /// Starts the stopwatch, and creates a new DispatcherTimer, for handling the countdown update.
        /// </summary>
        public override void Start(TextBlock tb)
        {
            ///Checks if the listBox is empty, by checking if the selected index = -1, to avoid an exception being thrown.
            if (listBoxTimers.SelectedIndex != -1)
            {
                ///starts the currently selected timers' stopwatch.
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
        void timer_Tick(object sender, EventArgs e)
        {
            ///Loops through all the timers in the timers List
            foreach (Timer timer in timers)
            {
                ///Checks if the stopwatch has reached the targetTime, if so it stops and clears the elapsed time on the stopwatch
                if (timer.TargetTime <= timer.CurrentTime.Elapsed)
                {
                    timer.CurrentTime.Reset();
                    timer.TargetTime = new TimeSpan(0, 0, 0);
                    UpdateTextBlock();
                }
            }
            UpdateListBox();
        }

        /// <summary>
        /// Method is called when the "Remove" button has been pressed.
        /// It removes the currently selected timer.
        /// </summary>
        internal void RemoveTimer()
        {
            ///Checks if the listBox is empty, by checking if the selected index = -1, to avoid an exception being thrown.
            if (listBoxTimers.SelectedIndex != -1)
            {
                ///Removes the selected timer.
                timers.RemoveAt(listBoxTimers.SelectedIndex);
                listBoxTimers.SelectedIndex = -1;
            }
            UpdateListBox();
        }

        /// <summary>
        /// Method is called when the "Stop" Button has been called. It Pauses the stopwatch.
        /// </summary>
        public override void Stop()
        {
            ///Checks if the listBox is empty, by checking if the selected index = -1, to avoid an exception being thrown.
            if (listBoxTimers.SelectedIndex != -1)
                ///Stops the selected alarms' stopwatch.
                timers[listBoxTimers.SelectedIndex].CurrentTime.Stop();
        }

        /// <summary>
        /// Method is called when a selection has changed in the listBox.
        /// Since the values in the listBox changes every tick, it constantly unselects any selected item in the listBox.
        /// This method makes sure that does'nt happen.
        /// </summary>
        internal void listBoxTimers_SelectionChanged()
        {
            ///Checks if the selected item is -1, which it becomes automatically every tick
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

        /// <summary>
        /// Method is called when the "Add" button has been pressed.
        /// It adds the user selected time to the current time remaining.
        /// </summary>
        public void AddTime()
        {
            ///Checks if the listBox is empty, by checking if the selected index = -1, to avoid an exception being thrown.
            if (listBoxTimers.SelectedIndex != -1)
            {
                ///Adds the user input to the selected Timers' time.
                timers[listBoxTimers.SelectedIndex].TargetTime = timers[listBoxTimers.SelectedIndex].TargetTime.Add(new TimeSpan(cbHours.SelectedIndex, cbMinutes.SelectedIndex, cbSeconds.SelectedIndex));
                cbHours.SelectedIndex = 0;
                cbMinutes.SelectedIndex = 0;
                cbSeconds.SelectedIndex = 0;
                UpdateTextBlock();
            }
        }

        /// <summary>
        /// Method is called when the "Subtract" button has been pressed.
        /// It removes the user specified time from the time remaing on the timer.
        /// </summary>
        public void SubtractTime()
        {
            ///Checks if the listBox is empty, by checking if the selected index = -1, to avoid an exception being thrown.
            if (listBoxTimers.SelectedIndex != -1)
            {
                ///Removes the user specified time from the selected timers' remaing time.
                timers[listBoxTimers.SelectedIndex].TargetTime = timers[listBoxTimers.SelectedIndex].TargetTime.Add(new TimeSpan(-cbHours.SelectedIndex, -cbMinutes.SelectedIndex, -cbSeconds.SelectedIndex));
                cbHours.SelectedIndex = 0;
                cbMinutes.SelectedIndex = 0;
                cbSeconds.SelectedIndex = 0;
                UpdateTextBlock();
            }
        }

        /// <summary>
        /// Method that is called once. It gives and sets some default values.
        /// </summary>
        public void Initialize(ComboBox cbHours, ComboBox cbMinutes, ComboBox cbSeconds)
        {
            this.cbHours = cbHours;
            this.cbMinutes = cbMinutes;
            this.cbSeconds = cbSeconds;

            ///A loop that adds every number between 0 and 25, to a comboBox that represents hours.
            for (int i = 0; i < 25; i++) { cbHours.Items.Add(i); }
            ///A loop that adds every number between 0 and 60, to a comboBox that represents minutes.
            for (int i = 0; i < 60; i++) { cbMinutes.Items.Add(i); cbSeconds.Items.Add(i); }

            ///Sets the selected indexes of the comboboxes to 0, to make sure that the calue can't be null.
            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;
            cbSeconds.SelectedIndex = 0;
        }

        /// <summary>
        /// Updates the contents of the ListBox
        /// </summary>
        public void UpdateListBox()
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
