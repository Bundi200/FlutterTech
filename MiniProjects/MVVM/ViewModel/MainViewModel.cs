using MiniProjects.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeCommand { get; set; }
        public RelayCommand NoteCommand { get; set; }
        
        public HomeViewModel HomeWM { get; set; }
        public NoteApplicationViewModel NoteApplicationWM { get; set; }

        private object _currentView;
        
        
        public Object CurrentView
        {
            get { return _currentView; } 
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() 
        {
            HomeWM = new HomeViewModel();
            NoteApplicationWM = new NoteApplicationViewModel();

            CurrentView = HomeWM;

            HomeCommand = new RelayCommand(o => { CurrentView = HomeWM; });
            NoteCommand = new RelayCommand(o => { CurrentView = NoteApplicationWM; });
        }
    }
}
