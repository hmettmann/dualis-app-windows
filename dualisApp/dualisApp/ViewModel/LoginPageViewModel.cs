// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginPageViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The login page view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Windows.Input;
using Windows.UI.Xaml;
using dualisApp.Misc;
using dualisApp.Model;

namespace dualisApp.ViewModel
{
    /// <summary>
	/// The login page view model.
	/// </summary>
	public class LoginPageViewModel :BaseViewModel
    {
		/// <summary>
		/// The _password.
		/// </summary>
		private string _password;

		/// <summary>
		/// The _email.
		/// </summary>
		private string _email;

		/// <summary>
		/// The _nick name.
		/// </summary>
		private string _nickName;

	    private bool _autoLogin;

	    /// <summary>
		/// Initializes a new instance of the <see cref="LoginPageViewModel"/> class.
		/// </summary>
		public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);

            //SetProgressRing(false);
            //var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //var autologin = localSettings.Values[nameof(AutoLogin)];
            //if (autologin != null && (autologin as bool?).Value)
            //{
            //    var userId = localSettings.Values["UserId"];
            //    if (userId is int)
            //    {
            //        DataHandler.DataHandler.Instance.GetCurrentUserData((int)userId);
            //        Login(null);
            //    }
            //}
}
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

	    /// <summary>
	    /// Gets or sets the login command.
	    /// </summary>
	    public ICommand LoginCommand { get; set; }

		/// <summary>
		/// The can login.
		/// </summary>
		/// <param name="obj">
		/// The obj.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public bool CanLogin(object obj)
        {
            if (string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                return true;
            }

            return false;
        }

		/// <summary>
		/// The login.
		/// </summary>
		/// <param name="obj">
		/// The obj.
		/// </param>
		public async void Login(object obj)
        {
            //SetProgressRing(true);
            //if (obj is Visibility && ((Visibility)obj) == Visibility.Collapsed)
            //{
            //    if (Email.Equals("t") || await DataHandler.DataHandler.Instance.Login(Email, Password) )
            //    {
            //        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //        localSettings.Values[nameof(AutoLogin)] = AutoLogin;
            //        FrameNavigator.NavigateTo(typeof(MainPageViewModel));
            //    }
            //    else
            //    {
            //        Password = string.Empty;
            //    }

            //}else if (obj is Visibility && ((Visibility) obj) == Visibility.Visible)
            //{
            //    AwaitRegister();
            //}
            //SetProgressRing(false);
        }

		/// <summary>
		/// The await register.
		/// </summary>
		private async void AwaitRegister()
        {
            //await DataHandler.DataHandler.Instance.CreateUser(new UserModel { Email = Email, Password = Password, NickName = NickName});

            //MessageDialogService service = new MessageDialogService();
            //SetProgressRing(false);
            //await service.ShowMessageDialogAsync("Vielen Dank für ihr Interesse an Meet2Eat. Die Registrierung war erfolgreich.\r\nEs wurde eine Email mit einem Bestätigungslink an ihre Email-Adresse gesandt. Bitte bestätigen sie ihren Account bevor sie versuchen sich einzuloggen."
            //                                     , "Registrierung erfolgreich");
        }
    }
}
