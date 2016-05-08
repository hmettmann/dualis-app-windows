// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginPage.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   An empty page that can be used on its own or navigated to within a Frame.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using dualisApp.Misc;
using dualisApp.ViewModel;

namespace dualisApp.View
{
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls;

	/// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="LoginPage"/> class.
		/// </summary>
		public LoginPage()
        {
            this.InitializeComponent();
            FrameNavigator.RegisterPage(typeof(LoginPage), typeof(LoginPageViewModel));
            FrameNavigator.RegisterPage(typeof(DayListViewPage), typeof(DayListViewPageViewModel));
            FrameNavigator.RegisterPage(typeof(MonthViewPage), typeof(MonthViewPageViewModel));
            FrameNavigator.RegisterPage(typeof(WeekViewPage), typeof(WeekViewPageViewModel));
            FrameNavigator.RegisterPage(typeof(SettingsPage), typeof(SettingsPageViewModel));
        }
    }
}
