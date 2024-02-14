using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MiniProjects.Core
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        public DateTime CurrentDateAndTime { get; set; }
        public event PropertyChangedEventHandler PropertyChanged; 
        public event PropertyChangedEventHandler PropertyChanged2;

        public ObservableObject() 
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(lbl_time);
            timer.Start();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void lbl_time(object sender, EventArgs e)
        {
            CurrentDateAndTime = DateTime.Now;
            PropertyChanged2(this, new PropertyChangedEventArgs(propertyName: "CurrentDateAndTime"));

        }
    }
}
