using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.TO;
using TCCApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCCApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaRecomendadosPage : ContentPage
	{
		public ListaRecomendadosPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LblErro.IsVisible = false;
            MessagingCenter.Subscribe<string>(this, HelperMessagingCenter.FalhaComunicacao, (msg) =>
            {
                LblErro.Text = msg;
                LblErro.IsVisible = true;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, HelperMessagingCenter.FalhaComunicacao);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ItemEvento;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetalheEventoPage(item.Id));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
}