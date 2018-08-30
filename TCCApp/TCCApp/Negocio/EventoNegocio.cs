using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.TO;
using TCCApi.CrudApi.Models;
using TCCApp.Services;
using Xamarin.Forms;

namespace TCCApp.Negocio
{
   

    public class EventoNegocio : IEventoNegocio
    {

        public EventoNegocio()
        {
            _EventoService = DependencyService.Get< IEventoService>();
        }

        public IEventoService _EventoService { get; }

        public async Task<IList<ItemEvento>> GetEventosEmAltaAsync()
        {
            return await _EventoService.GetEventosEmAltaAsync();
        }

        public async Task<IList<ItemEvento>> GetEventosRecomendacaoAsync()
        {
            return await _EventoService.GetEventosRecomendacaoAsync();
        }

        public async Task<IList<ItemEvento>> GetEventosUltimasVisitasAsync()
        {
            return await _EventoService.GetEventosUltimasVisitasAsync();
        }

        public async Task<Evento> GetEventoAsync(int codEvento)
        {
            return await _EventoService.GetEventoAsync(codEvento);
        }

        public async Task<IList<ItemEvento>> GetEventosSimilaresAsync(int codEvento)
        {
            return await _EventoService.GetEventoSimilaresAsync(codEvento);
        }
    }
}
