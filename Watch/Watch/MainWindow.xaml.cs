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
        private MyAlarm ma;
        private MyStopwatch msw;
        private MyTimer mt;
        private VisualRepWatch vrw;

        public MainWindow()
        {
            InitializeComponent();
            ///A new DispatcherTimer is created, which updates the current Time and date, displayed on the main screen
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Text = DateTime.Now.ToString("HH:mm:ss");
                this.textBlockDate.Text = String.Format("{0:00}/{1:00}-{2:0000}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }, this.Dispatcher);

            ///A new instance of the MyAlarm class is created, and all the tools it needs is passed as arguments.
            ma = new MyAlarm(txtBoxAlarmName, datePickerAlarm, textBoxAlarmMessage, listBoxAlarms, comboBoxAlarmHours, comboBoxAlarmMinutes, radioBtnOn, radioBtnOff);
            ///A new instance if the MyTimer class is created, and all the tools it needs is passed as arguments.
            mt = new MyTimer(Dispatcher, textBlockTimer, listBoxTimers);
            ///A new instance of the MyStopwatch class is created.
            msw = new MyStopwatch();
            ///The Timers intitialize method is called
            mt.Initialize(comboBoxTimerHours, comboBoxTimerMinutes, comboBoxTimerSeconds);

            ///A new instance of the VisualRepWatch class is created
            vrw = new VisualRepWatch(canvas);
        }

        #region StopWatch Eventhandlers

        /// <summary>
        /// The eventhandlers in this region all call their respectice methods in the stopwatch class
        /// </summary>

        private void btnStartStopwatch_Click(object sender, RoutedEventArgs e)
        {
            msw.Start(textBlockStopwatch);
        }

        private void btnStopStopWatch_Click(object sender, RoutedEventArgs e)
        {
            msw.Stop();
        }

        private void btnResetStopWatch_Click(object sender, RoutedEventArgs e)
        {
            msw.Reset();
        }

        private void btnLapStopwatch_Click(object sender, RoutedEventArgs e)
        {
            msw.Lap(listBoxStopwatchLaps);
        }
        #endregion

        #region Timer EventHandlers

        /// <summary>
        /// The eventhandlers in this region all call their respective methods in Timer class
        /// </summary>

        private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        {
            mt.Start(textBlockTimer);
        }

        private void btnStopTimer_Click(object sender, RoutedEventArgs e)
        {
            mt.Stop();
        }

        private void btnResetTimer_Click(object sender, RoutedEventArgs e)
        {
            mt.Reset();
        }

        private void btnTimerAddTime_Click(object sender, RoutedEventArgs e)
        {
            mt.AddTime();
        }

        private void btnTimerSubtractTime_Click(object sender, RoutedEventArgs e)
        {
            mt.SubtractTime();
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mt.New();
        }

        private void listBoxTimers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mt.listBoxTimers_SelectionChanged();
        }

        private void btnRemoveTimer_Click(object sender, RoutedEventArgs e)
        {
            mt.RemoveTimer();
        }
        #endregion

        #region Alarm Eventhandlers

        /// <summary>
        /// The Eventhandlers in this region all call their respective methods in the Alarm class
        /// </summary>

        private void btnNewAlarm_Click(object sender, RoutedEventArgs e) => ma.CreateNew();

        private void listBoxAlarms_SelectionChanged(object sender, SelectionChangedEventArgs e) => ma.listBoxAlarms_SelectionChanged();

        private void radioBtnOff_Checked(object sender, RoutedEventArgs e) => ma.RadioBtnSelectonChanged();

        private void btnAlarmRemove_Click(object sender, RoutedEventArgs e) => ma.Remove();

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e) => ma.SaveChanges();
        #endregion

    }
}
