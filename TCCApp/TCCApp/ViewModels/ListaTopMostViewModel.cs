using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TCC.Models.TO;
using TCCApp.Helpers;
using TCCApp.Negocio;
using Xamarin.Forms;

namespace TCCApp.ViewModels
{
    public class ListaTopMostViewModel : BaseViewModel
    {
        private IEventoNegocio _EventoNegocio;

        public string Titulo { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public ObservableCollection<ItemEvento> Items { get; set; }
        public ICommand LoadItemsCommand { get; set; }

        public ListaTopMostViewModel()
        {

            try
            {
                _EventoNegocio = DependencyService.Get<IEventoNegocio>();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            Titulo = "Recomendados";
            Items = new ObservableCollection<ItemEvento>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _EventoNegocio.GetEventosEmAltaAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send<string>("Não foi possivel Comunicar com o servidor", HelperMessagingCenter.FalhaComunicacao);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
