using System;
using System.Collections.Generic;
using System.Text;
using TCCApi.CrudApi.Models;

namespace TCCApp.ViewModels
{
    public class EfetuarCompraViewModel : BaseViewModel
    {
        private readonly Evento evento;

        public EfetuarCompraViewModel(Evento evento)
        {
            this.evento = evento;
        }
    }
}
