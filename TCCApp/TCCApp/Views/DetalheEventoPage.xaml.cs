using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.TO;
using TCCApi.CrudApi.Models;
using TCCApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCCApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheEventoPage : TabbedPage
	{
		public DetalheEventoPage (int CodEvento)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new DetalheEventoViewModel(CodEvento);
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