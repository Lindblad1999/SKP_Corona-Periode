using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Watch.WatchObjects;

namespace Watch.Watches
{
    public class MyAlarm
    {
        private TextBox name;
        private DatePicker datePickerAlarm;
        private TextBox message;
        private ListBox listBoxAlarms;
        private ComboBox cbHours;
        private ComboBox cbMinutes;

        private List<Alarm> alarms;

        public MyAlarm(TextBox name, DatePicker datePickerAlarm, TextBox message, ListBox listBoxAlarms, ComboBox cbHours, ComboBox cbMinutes)
        {
            this.name = name;
            this.datePickerAlarm = datePickerAlarm;
            this.message = message;
            this.listBoxAlarms = listBoxAlarms;
            this.cbHours = cbHours;
            this.cbMinutes = cbMinutes;
            this.alarms = new List<Alarm>();

            Initialize();
        }

        public void CreateNew()
        {
            alarms.Add(new Alarm(name.Text, message.Text, datePickerAlarm.DisplayDate, cbHours.SelectedIndex, cbMinutes.SelectedIndex));
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBoxAlarms.Items.Clear();
            foreach (Alarm alarm in alarms)
                listBoxAlarms.Items.Add(String.Format("{0}\n{1}\n{2}\n-", alarm.Name, alarm.TargetTime.ToString(), alarm.Message));
        }

        private void Initialize()
        {
            for (int i = 0; i < 24; i++) cbHours.Items.Add(i);
            for (int i = 0; i < 60; i++) cbMinutes.Items.Add(i);

            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;
        }
    }
}
