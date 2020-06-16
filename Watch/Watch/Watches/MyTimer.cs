
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
        private Dispatcher dispatcher;
        private TextBlock tb;
        private TimeSpan ts;
        private DateTime endTime;
        private bool isRunning;
        private DispatcherTimer timer;

        public MyTimer(Dispatcher dispatcher, TextBlock tb)
        {
            this.dispatcher = dispatcher;
            this.tb = tb;
            isRunning = false;
        }


        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override void Start(TextBlock tb)
        {
            isRunning = true;
            this.tb = tb;
            endTime = endTime.Add(new TimeSpan(DateTime.Now.Day - 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            endTime = endTime.AddMonths(DateTime.Now.Month - 1);
            endTime = endTime.AddYears(DateTime.Now.Year - 1);

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                ts = endTime - DateTime.Now;
                tb.Text = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            }, dispatcher);

            timer.Tick += new EventHandler(timer_Tick);

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (ts.Hours <= 0 && ts.Minutes <= 0 && ts.Seconds <= 0)
            {
                timer.Stop();
                ts = new TimeSpan();
                endTime = new DateTime();
                isRunning = false;
            }
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }

        private void UpdateTextBlock()
        {
            tb.Text = String.Format("{0:00}:{1:00}:{2:00}", endTime.Hour, endTime.Minute, endTime.Second);
        }

        public void AlterHours(int hours)
        {
            if (endTime.Hour + hours < 0)
                return;
            endTime = endTime.AddHours(hours); 
            if (!isRunning) 
                UpdateTextBlock(); 
        }
        public void AlterMinutes(int minutes) { endTime = endTime.AddMinutes(minutes); if (!isRunning) UpdateTextBlock(); }
        public void AlterSeconds(int seconds) { endTime = endTime.AddSeconds(seconds); if (!isRunning) UpdateTextBlock(); }
    }
}
