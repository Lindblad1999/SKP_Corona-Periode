using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Watch.Watches
{
    public abstract class Watch
    {
        public TextBlock tb;
        public DispatcherTimer timer;

        public abstract void Start(TextBlock tb);
        public abstract void Stop();
        public abstract void Reset();
    }
}
