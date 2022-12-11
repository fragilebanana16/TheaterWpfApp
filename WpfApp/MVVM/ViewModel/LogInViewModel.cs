using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Core;
using WpfApp.MVVM.Model;
using WpfApp.Repository;

namespace WpfApp.MVVM.ViewModel
{
    class LogInViewModel : ObservableObject
    {
        private string _username="Hrt";

        private string _password=" ";

        private string _errormessage;

        private bool _isViewVisible=true;

        private IUserRepository userRepository;

        public string Username 
        { 
            get => _username; 
            set
            {
                _username = value;
                OnPropertyChanged();
            } 
        }

        public string Password 
        { 
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage 
        { 
            get => _errormessage;
            set
            {
                _errormessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsViewVisible 
        { 
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LogInViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new RelayCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object arg)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrEmpty(Password))
            {
                isValid = false;
            }

            return isValid;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null); // 注册用户?
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }
    }
}
