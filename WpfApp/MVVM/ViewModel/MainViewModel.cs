using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp.Core;
using WpfApp.MVVM.Model;
using WpfApp.Repository;

namespace WpfApp.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MovieViewCommand { get; set; }
        public RelayCommand OtherViewCommand { get; set; }

        private object _currentView;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
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

            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            try
            {
#if DEBUG

#else
                var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                if (user != null)
                {
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"Welcome {user.ID} {user.Email} ;)";
                    CurrentUserAccount.ProfilePicture = null;
                }
                else
                {
                    CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                    //Hide child views.
                }
#endif

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
