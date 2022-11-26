using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Core;

namespace WpfApp.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MovieViewCommand { get; set; }
        public RelayCommand OtherViewCommand { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged(); 
            }
        }

        public HomeViewModel HomeVM { get; set; }
        public MovieViewModel MovieVM { get; set; }

        public OtherViewModel OtherVM { get; set; }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            MovieVM = new MovieViewModel();
            OtherVM = new OtherViewModel();
            CurrentView = HomeVM;
            HomeViewCommand = new RelayCommand(obj => 
            { 
                CurrentView = HomeVM; 
            });

            MovieViewCommand = new RelayCommand(obj =>
            {
                CurrentView = MovieVM;
            });

            OtherViewCommand = new RelayCommand(obj =>
            {
                CurrentView = OtherVM;
            });
        }
    }
}
