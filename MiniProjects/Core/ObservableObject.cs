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
        private DateTime _currentDateAndTime;

        public DateTime CurrentDateAndTime
        {
            get { return _currentDateAndTime; }
            set
            {
                if (_currentDateAndTime != value)
                {
                    _currentDateAndTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



        public ObservableObject()
        {
            InitializeTimer();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void InitializeTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentDateAndTime = DateTime.Now;

        }
    }
}
