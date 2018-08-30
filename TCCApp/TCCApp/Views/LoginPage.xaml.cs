using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCCApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCCApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, HelperMessagingCenter.LoginFail, async (data) =>
            {
                
               await UserDialogs.Instance.AlertAsync(data);
            });
            MessagingCenter.Subscribe<string>(this, HelperMessagingCenter.LoginSucess, (data) =>
            {
                Navigation.PushAsync((new MainPage()));
            });
            MessagingCenter.Subscribe<string>(this, HelperMessagingCenter.OpenRegister,(data) =>
            {
                Navigation.PushAsync(new AboutPage());
            });
            MessagingCenter.Subscribe<string>(this, HelperMessagingCenter.OpenEsqueciMinhaSenha, (data) =>
            {
                Navigation.PushAsync((new AboutPage()));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, HelperMessagingCenter.LoginFail);
            MessagingCenter.Unsubscribe<string>(this, HelperMessagingCenter.LoginSucess);
            MessagingCenter.Unsubscribe<string>(this, HelperMessagingCenter.OpenRegister);
            MessagingCenter.Unsubscribe<string>(this, HelperMessagingCenter.OpenEsqueciMinhaSenha);
        }
    }
}