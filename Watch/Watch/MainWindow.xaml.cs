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

namespace Watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyWatch mw;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Text = DateTime.Now.ToString("HH:mm:ss");
                this.textBlockDate.Text = String.Format("{0:00}/{1:00}-{2:0000}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            }, this.Dispatcher);

            mw = new MyWatch(this.Dispatcher, textBlockTimer);
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

        }
        #endregion

        #region Timer EventHandlers
        private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        {
            mw.myTimer.Start(textBlockTimer);
        }

        #region AddAndSubtractTimeButtons
        private void btnTenHoursPlus_Click(object sender, RoutedEventArgs e) { mw.myTimer.AlterHours(10); }

        private void btnOneHoursPlus_Click(object sender, RoutedEventArgs e){mw.myTimer.AlterHours(1);}

        private void btnTenMinutesPlus_Click(object sender, RoutedEventArgs e){mw.myTimer.AlterMinutes(10);}

        private void btnOneMinutePlus_Click(object sender, RoutedEventArgs e){mw.myTimer.AlterMinutes(1);}

        private void btnTenSecondsPlus_Click(object sender, RoutedEventArgs e){mw.myTimer.AlterSeconds(10);}

        private void btnOneSecondPlus_Click(object sender, RoutedEventArgs e){mw.myTimer.AlterSeconds(1);}

        private void btnTenHoursMinus_Click(object sender, RoutedEventArgs e) { mw.myTimer.AlterHours(-10); }

        private void btnOneHoursMinusPlus_Copy_Click(object sender, RoutedEventArgs e) { mw.myTimer.AlterHours(-1); }

        private void btnTenMinutesMinus_Click(object sender, RoutedEventArgs e) { mw.myTimer.AlterMinutes(-10); }

        private void btnOneMinuteMinus_Click(object sender, RoutedEventArgs e) { mw.myTimer.AlterMinutes(-1); }

        private void btnTenSecondsMinus_Click(object sender, RoutedEventArgs e) { mw.myTimer.AlterSeconds(-10); }

        private void btnOneSecondMinus_Click(object sender, RoutedEventArgs e) { mw.myTimer.AlterSeconds(-1); }
        #endregion
        #endregion

    }
}
