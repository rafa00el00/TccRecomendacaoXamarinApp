using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCCApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
		}
	}
}