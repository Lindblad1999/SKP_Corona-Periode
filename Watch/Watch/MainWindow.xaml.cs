using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Watch.Watches;

namespace Watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyWatch mw;
        private MyAlarm ma;


        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Text = DateTime.Now.ToString("HH:mm:ss");
                this.textBlockDate.Text = String.Format("{0:00}/{1:00}-{2:0000}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }, this.Dispatcher);

            ma = new MyAlarm(txtBoxAlarmName, datePickerAlarm, textBoxAlarmMessage, listBoxAlarms, comboBoxAlarmHours, comboBoxAlarmMinutes);
            mw = new MyWatch(this.Dispatcher, textBlockTimer, listBoxTimers);
            mw.myTimer.Initialize(comboBoxTimerHours, comboBoxTimerMinutes, comboBoxTimerSeconds);
        }

        #region StopWatch Eventhandlers
        private void btnStartStopwatch_Click(object sender, RoutedEventArgs e)
        {
            mw.myStopwatch.Start(textBlockStopwatch);
        }

        private void btnStopStopWatch_Click(object sender, RoutedEventArgs e)
        {
            mw.myStopwatch.Stop();
        }

        private void btnResetStopWatch_Click(object sender, RoutedEventArgs e)
        {
            mw.myStopwatch.Reset();
        }

        private void btnLapStopwatch_Click(object sender, RoutedEventArgs e)
        {
            mw.myStopwatch.Lap(listBoxStopwatchLaps);
        }
        #endregion

        #region Timer EventHandlers
        private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.Start(textBlockTimer);
        }

        private void btnStopTimer_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.Stop();
        }

        private void btnResetTimer_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.Reset();
        }

        private void btnTimerAddTime_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.AddTime();
        }

        private void btnTimerSubtractTime_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.SubtractTime();
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.New();
        }

        private void listBoxTimers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mw.myTimer.listBoxTimers_SelectionChanged();
        }

        private void btnRemoveTimer_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.RemoveTimer();
        }
        #endregion

        #region Alarm Eventhandlers
        private void btnNewAlarm_Click(object sender, RoutedEventArgs e)
        {
            ma.CreateNew();
        }

        #endregion

    }
}
