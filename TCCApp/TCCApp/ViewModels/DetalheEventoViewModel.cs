using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TCC.Models.TO;
using TCCApi.CrudApi.Models;
using TCCApp.Helpers;
using TCCApp.Negocio;
using Xamarin.Forms;

namespace TCCApp.ViewModels
{
    public class DetalheEventoViewModel : BaseViewModel
    {
        private IEventoNegocio _EventoNegocio;

        public string Titulo { get; }

        private Evento _evento;
        public Evento evento { get=> _evento; set => SetProperty(ref _evento,value); }

        public ObservableCollection<ItemEvento> Items { get; set; }
        public ICommand LoadItemsCommand { get; set; }
        public ICommand ComprarCommand { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool isBusySimilares = false;
        public bool IsBusySimilares
        {
            get { return isBusySimilares; }
            set { SetProperty(ref isBusySimilares, value); }
        }

        public int CodEvento { get; }

        public DetalheEventoViewModel()
        {
            _EventoNegocio = DependencyService.Get<IEventoNegocio>();
            
        }
        public DetalheEventoViewModel(int CodEvento): this()
        {
            ExecuteLoad(CodEvento);
            this.CodEvento = CodEvento;
            Titulo = "Recomendados";
            Items = new ObservableCollection<ItemEvento>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null);
        }

        public DetalheEventoViewModel(Evento evento)
        {
            this.evento = evento;
            CodEvento = evento.Id;
            Titulo = "Recomendados";
            Items = new ObservableCollection<ItemEvento>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null);
        }

        async Task ExecuteLoad(int codItem)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                
                evento = await _EventoNegocio.GetEventoAsync(codItem);
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

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusySimilares)
                return;

            IsBusySimilares = true;

            try
            {
                Items.Clear();
                var items = await _EventoNegocio.GetEventosSimilaresAsync(CodEvento);
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
                IsBusySimilares = false;
            }
        }

    }
}
