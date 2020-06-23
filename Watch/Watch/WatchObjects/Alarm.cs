using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch.WatchObjects
{
    public class Alarm
    {
        private DateTime? targetTime;
        private string name;
        private string message;
        private bool isOn;

        public DateTime? TargetTime
        {
            get => this.targetTime;
            set
            {
                if (value.Value > DateTime.Now)
                    this.targetTime = value;
                else
                    throw new ArgumentException("Date can't be below the current date");
            }
        }
        public string Name { get => this.name; set { this.name = value; } }
        public string Message { get => this.message; set { this.message = value; } }
        public bool IsOn { get => this.isOn; set { this.isOn = value; } }

        public Alarm(string name, string message, DateTime? date, int hours, int minutes)
        {
            this.Name = name;
            this.Message = message;

            this.TargetTime = date;
            TargetTime = TargetTime.Value.AddHours(hours);
            TargetTime = TargetTime.Value.AddMinutes(minutes);

            isOn = true;
        }
    }
}
