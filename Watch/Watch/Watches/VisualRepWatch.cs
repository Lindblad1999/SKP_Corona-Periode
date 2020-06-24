using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Watch.Watches
{
    public class VisualRepWatch
    {
        private DispatcherTimer timer;
        private Canvas c;

        public VisualRepWatch(Canvas c)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();

            this.c = c;

        }

        void timer_Tick(object sender, EventArgs e)
        {
            DrawHours();
            DrawMinutes();
            DrawSeconds();
        }

        private void DrawSeconds()
        {
            int marginLeft = 10;
            int marginTop = 120;
            for (int i = 1; i < 6; i++)
            {
                Ellipse el = new Ellipse();
                SolidColorBrush s = new SolidColorBrush();

                if (i * 10 <= DateTime.Now.Second)
                    s.Color = Color.FromRgb(0, 255, 0);
                else
                    s.Color = Color.FromRgb(255, 255, 255);

                el.Fill = s;
                el.StrokeThickness = 1;
                el.Stroke = Brushes.Black;
                el.Height = 30;
                el.Width = 30;

                el.Margin = new System.Windows.Thickness(marginLeft, marginTop, 0, 0);

                marginLeft += 40;

                c.Children.Add(el);
            }

            marginTop = 160;
            marginLeft = 25;
            for (int i = 1; i < 10; i++)
            {
                Ellipse el = new Ellipse();
                SolidColorBrush s = new SolidColorBrush();

                if (DateTime.Now.Second.ToString().Length > 1)
                    if (i <= Convert.ToInt32(DateTime.Now.Second.ToString().Substring(1, 1)))
                        s.Color = Color.FromRgb(0, 255, 0);
                    else
                        s.Color = Color.FromRgb(255, 255, 255);
                else
                {
                    if (i <= DateTime.Now.Second)
                        s.Color = Color.FromRgb(0, 255, 0);
                    else
                        s.Color = Color.FromRgb(255, 255, 255);
                }

                el.Fill = s;
                el.StrokeThickness = 1;
                el.Stroke = Brushes.Black;
                el.Height = 20;
                el.Width = 20;

                el.Margin = new System.Windows.Thickness(marginLeft, marginTop, 0, 0);

                marginLeft += 30;

                c.Children.Add(el);
            }
        }

        private void DrawMinutes()
        {
            int marginLeft = 10;
            int marginTop = 50;
            for (int i = 1; i < 6; i++)
            {
                Ellipse el = new Ellipse();
                SolidColorBrush s = new SolidColorBrush();

                if (i * 10 <= DateTime.Now.Minute)
                    s.Color = Color.FromRgb(0, 0, 255);
                else
                    s.Color = Color.FromRgb(255, 255, 255);

                el.Fill = s;
                el.StrokeThickness = 1;
                el.Stroke = Brushes.Black;
                el.Height = 30;
                el.Width = 30;

                el.Margin = new System.Windows.Thickness(marginLeft, marginTop, 0, 0);

                marginLeft += 40;

                c.Children.Add(el);
            }

            marginTop = 90;
            marginLeft = 25;
            for (int i = 1; i < 10; i++)
            {
                Ellipse el = new Ellipse();
                SolidColorBrush s = new SolidColorBrush();

                if (DateTime.Now.Minute.ToString().Length > 1)
                    if (i <= Convert.ToInt32(DateTime.Now.Minute.ToString().Substring(1, 1)))
                        s.Color = Color.FromRgb(0, 0, 255);
                    else
                        s.Color = Color.FromRgb(255, 255, 255);
                else
                {
                    if (i <= DateTime.Now.Minute)
                        s.Color = Color.FromRgb(0, 0, 255);
                    else
                        s.Color = Color.FromRgb(255, 255, 255);
                }


                el.Fill = s;
                el.StrokeThickness = 1;
                el.Stroke = Brushes.Black;
                el.Height = 20;
                el.Width = 20;

                el.Margin = new System.Windows.Thickness(marginLeft, marginTop, 0, 0);

                marginLeft += 30;

                c.Children.Add(el);
            }
        }

        private void DrawHours()
        {
            int marginLeft = 10;
            int marginTop = 10;
            for (int i = 1; i < 13; i++)
            {
                Ellipse el = new Ellipse();
                SolidColorBrush s = new SolidColorBrush();

                if (i <= DateTime.Now.Hour && DateTime.Now.Hour <= 12)
                    s.Color = Color.FromRgb(0, 0, 255);
                else if (i > DateTime.Now.Hour)
                    s.Color = Color.FromRgb(255, 255, 255);
                else if (i + 12 <= DateTime.Now.Hour && DateTime.Now.Hour > 12)
                    s.Color = Color.FromRgb(255, 0, 0);

                el.Fill = s;
                el.StrokeThickness = 1;
                el.Stroke = Brushes.Black;
                el.Height = 20;
                el.Width = 20;

                el.Margin = new System.Windows.Thickness(marginLeft, marginTop, 0, 0);

                marginLeft += 30;

                c.Children.Add(el);
            }
        }
    }
}
