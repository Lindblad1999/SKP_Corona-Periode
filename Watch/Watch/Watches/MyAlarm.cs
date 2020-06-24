using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Watch.WatchObjects;
using System.Windows;
using System.Windows.Threading;
using System.Configuration;

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
        private RadioButton radioBtnOn;
        private RadioButton radioBtnOff;

        private List<Alarm> alarms;
        private DispatcherTimer timer;

        public MyAlarm(TextBox name, DatePicker datePickerAlarm, TextBox message, ListBox listBoxAlarms,
            ComboBox cbHours, ComboBox cbMinutes, RadioButton radioBtnOn, RadioButton radioBtnOff)
        {
            this.name = name;
            this.datePickerAlarm = datePickerAlarm;
            this.message = message;
            this.listBoxAlarms = listBoxAlarms;
            this.cbHours = cbHours;
            this.cbMinutes = cbMinutes;
            this.radioBtnOn = radioBtnOn;
            this.radioBtnOff = radioBtnOff;
            this.alarms = new List<Alarm>();

            timer = new DispatcherTimer();

            Initialize();
        }

        public void CreateNew()
        {
            try
            {
                alarms.Add(new Alarm(name.Text, message.Text, datePickerAlarm.SelectedDate, cbHours.SelectedIndex, cbMinutes.SelectedIndex));
                UpdateListBox();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateListBox()
        {
            listBoxAlarms.Items.Clear();
            foreach (Alarm alarm in alarms)
            {
                listBoxAlarms.Items.Add(String.Format("{0}\n{1}\n{2}\n-", alarm.Name, alarm.TargetTime.Value, alarm.Message));
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < 24; i++) cbHours.Items.Add(i);
            for (int i = 0; i < 60; i++) cbMinutes.Items.Add(i);

            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            foreach (Alarm alarm in alarms)
            {
                if (alarm.TargetTime.Value <= DateTime.Now && alarm.IsOn)
                {
                    switch (MessageBox.Show($"{alarm.Name}\n{alarm.Message}\n\nSnooze?", "Ring Ring!", MessageBoxButton.YesNo))
                    {
                        case MessageBoxResult.Yes:
                            alarm.TargetTime = alarm.TargetTime.Value.AddMinutes(10);
                            UpdateListBox();
                            break;
                        case MessageBoxResult.No:
                            alarm.IsOn = false;
                            break;
                    }
                }
            }
        }

        public void listBoxAlarms_SelectionChanged()
        {
            if (listBoxAlarms.SelectedIndex != -1)
            {
                if (alarms[listBoxAlarms.SelectedIndex].IsOn)
                    radioBtnOn.IsChecked = true;
                else
                    radioBtnOff.IsChecked = true;

                name.Text = alarms[listBoxAlarms.SelectedIndex].Name;
                datePickerAlarm.SelectedDate = alarms[listBoxAlarms.SelectedIndex].TargetTime.Value.Date;
                message.Text = alarms[listBoxAlarms.SelectedIndex].Message;
                cbHours.SelectedItem = alarms[listBoxAlarms.SelectedIndex].TargetTime.Value.Hour;
                cbMinutes.SelectedItem = alarms[listBoxAlarms.SelectedIndex].TargetTime.Value.Minute;
            }
        }

        public void RadioBtnSelectonChanged()
        {
            if (radioBtnOn.IsChecked.Value)
                if (listBoxAlarms.SelectedIndex != -1)
                    alarms[listBoxAlarms.SelectedIndex].IsOn = true;
                else
                    alarms[listBoxAlarms.SelectedIndex].IsOn = false;
        }

        public void Remove()
        {
            if (listBoxAlarms.SelectedIndex != -1)
                alarms.RemoveAt(listBoxAlarms.SelectedIndex); UpdateListBox();
        }

        public void SaveChanges()
        {
            if (listBoxAlarms.SelectedIndex != -1)
            {
                DateTime? tempDate = datePickerAlarm.SelectedDate;
                tempDate = tempDate.Value.AddHours(cbHours.SelectedIndex);
                tempDate = tempDate.Value.AddMinutes(cbMinutes.SelectedIndex);

                try
                {
                    alarms[listBoxAlarms.SelectedIndex].TargetTime = tempDate;
                    alarms[listBoxAlarms.SelectedIndex].Name = name.Text;
                    alarms[listBoxAlarms.SelectedIndex].Message = message.Text;
                }
                catch (Exception e) { MessageBox.Show(e.Message); }

                UpdateListBox();
            }
        }
    }
}
