﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch.WatchObjects
{
    public class Alarm
    {
        private DateTime targetTime;
        private string name;
        private string message;

        public DateTime TargetTime { get => this.targetTime; set { this.targetTime = value; } }
        public string Name { get => this.name; set { this.name = value; } }
        public string Message { get => this.message; set { this.message = value; } }

        public Alarm(string name, string message, DateTime date, int hours, int minutes)
        {
            this.Name = name;
            this.Message = message;

            this.TargetTime = date;
            TargetTime.AddHours(hours);
            TargetTime.AddMinutes(minutes);
        }
    }
}