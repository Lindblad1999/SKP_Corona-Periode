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

            mw = new MyWatch();
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

    }
}
