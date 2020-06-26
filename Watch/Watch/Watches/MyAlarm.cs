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
using System.Windows.Media.Animation;
using Watch.Interfaces;

namespace Watch.Watches
{
    public class MyAlarm : IUpdate
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

        /// <summary>
        /// Method is called when the "Create new" button is pressed.
        /// It creates a new Alarm.
        /// </summary>
        public void CreateNew()
        {
            ///Attempts to add a new instance of the Alarm class, to the list of Alarm's, and passes,
            ///the various user input as arguments.
            ///If a user input is invalid, an exception is thrown, that will be shown in a messagebox.
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

        /// <summary>
        /// Updates the contents of the listBox
        /// </summary>
        public void UpdateListBox()
        {
            listBoxAlarms.Items.Clear();
            ///Goes through all the Alarm's in the alarms List.
            foreach (Alarm alarm in alarms)
            {
                ///Adds a formatted string containing information about the current Alarm.
                listBoxAlarms.Items.Add(String.Format("{0}\n{1}\n{2}\n-", alarm.Name, alarm.TargetTime.Value, alarm.Message));
            }
        }

        /// <summary>
        /// Method that is run once, in the constructor.
        /// It Gives and sets some default values.
        /// </summary>
        private void Initialize()
        {
            ///A loop that adds every number between 0 and 24, to a comboBox that represents hours.
            for (int i = 0; i < 24; i++) cbHours.Items.Add(i);
            ///A loop that adds every number between 0 and 60, to a comboBox that represents minutes.
            for (int i = 0; i < 60; i++) cbMinutes.Items.Add(i);

            ///Sets the selected index of both comboboxes to 0. This is done so the selected value cannot be null.
            cbHours.SelectedIndex = 0;
            cbMinutes.SelectedIndex = 0;

            ///Creates a new eventhanler, that runs every tick.
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        /// <summary>
        /// Eventhandler that runs every tick. it checks whether an alarm matches the current time or not.
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            ///Loops through all the Alarm's in the alarms List.
            foreach (Alarm alarm in alarms)
            {
                ///Checks if the current alarm's target time, has hot the current time, and whether the alarm is on or not.
                ///This is done to know whether to alarm should ring or not.
                if (alarm.TargetTime.Value <= DateTime.Now && alarm.IsOn)
                {
                    ///Displays a messagebox and asks the user whether to snooze or not. A switch/case then handles the answer.
                    switch (MessageBox.Show($"{alarm.Name}\n{alarm.Message}\n\nSnooze?", "Ring Ring!", MessageBoxButton.YesNo))
                    {
                        ///if snooze has been chosen.
                        case MessageBoxResult.Yes:
                            ///Adds 10 minutes to the alarm.
                            alarm.TargetTime = alarm.TargetTime.Value.AddMinutes(10);
                            UpdateListBox();
                            break;
                        ///if snooze has not been chosen.
                        case MessageBoxResult.No:
                            alarm.IsOn = false; ///Turns on the alarm.
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Method is called when a selection has changed in the listBox. It sets the data of the variuos
        /// tools on the window to match the selected alarm
        /// </summary>
        public void listBoxAlarms_SelectionChanged()
        {
            ///Checks if the selected index is -1. This is because if the listBox is empty, hte index will be set to -1, and 
            ///an exception will be thrown.
            if (listBoxAlarms.SelectedIndex != -1)
            {
                ///Checks if the current selected Alarm is on or off, and sets the radiobutton accordingly.
                if (alarms[listBoxAlarms.SelectedIndex].IsOn)
                    radioBtnOn.IsChecked = true;
                else
                    radioBtnOff.IsChecked = true;

                ///Sets all the tools' data in the window, to the currently selected alarms data.
                name.Text = alarms[listBoxAlarms.SelectedIndex].Name;
                datePickerAlarm.SelectedDate = alarms[listBoxAlarms.SelectedIndex].TargetTime.Value.Date;
                message.Text = alarms[listBoxAlarms.SelectedIndex].Message;
                cbHours.SelectedItem = alarms[listBoxAlarms.SelectedIndex].TargetTime.Value.Hour;
                cbMinutes.SelectedItem = alarms[listBoxAlarms.SelectedIndex].TargetTime.Value.Minute;
            }
        }

        /// <summary>
        /// Method is run when a selection has changed on the radio buttons. It sets the currently selected alarm to on/off accordingly
        /// </summary>
        public void RadioBtnSelectonChanged()
        {
            ///Checks if the Radio Button that represents ON is checked.
            if (radioBtnOn.IsChecked.Value)
                if (listBoxAlarms.SelectedIndex != -1) /// Checks if the selected index in the listbox is not -1, to avoid an exception being thrown.
                    alarms[listBoxAlarms.SelectedIndex].IsOn = true;
                else
                    alarms[listBoxAlarms.SelectedIndex].IsOn = false;
        }

        /// <summary>
        /// Method is called when the "Remove" button has been pressed. removes the currently selected alarm from the list.
        /// </summary>
        public void Remove()
        {
            ///Checks if the selected index in the listbox is not -1, to avoid an exception being thrown
            if (listBoxAlarms.SelectedIndex != -1)
                ///Removes the selected alarm from the list, and updates the listbox.
                alarms.RemoveAt(listBoxAlarms.SelectedIndex); UpdateListBox();
        }

        /// <summary>
        /// Method is called when the "Save" button has been pressed. it saves any changes made to an alam.
        /// </summary>
        public void SaveChanges()
        {
            ///Checks if selected index in the listbox is not -1, to avoid an exceprion
            if (listBoxAlarms.SelectedIndex != -1)
            {
                ///Attempts to set the user input data to the seleted alarms data.
                ///Checks for an exception, in case some user input is invalid.
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
