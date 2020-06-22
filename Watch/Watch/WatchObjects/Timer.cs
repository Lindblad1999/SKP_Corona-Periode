using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch.WatchObjects
{
    public class Timer
    {
        private TimeSpan targetTime;
        private Stopwatch currentTime;

        public TimeSpan TargetTime
        { get => this.TargetTime;
            set 
            {
                if (value.Hours >= 0 && value.Minutes >= 0 && value.Seconds >= 0 && value.Days <= 0)
                    this.targetTime = value;
            } 
        }
        public Stopwatch CurrentTime { get; set; }

        /// <summary>
        /// Cunstructor creates new instances of targetTime, and currentTime.
        /// </summary>
        public Timer()
        {
            targetTime = new TimeSpan(0, 0, 0);
            currentTime = new Stopwatch();
        }
    }
}