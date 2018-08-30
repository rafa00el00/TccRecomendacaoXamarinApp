using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Models.TO;
using TCCApi.CrudApi.Models;
using TCCApp.Services;

namespace TCCApp.Negocio
{
    public interface IEventoNegocio
    {
        IEventoService _EventoService { get; }

        Task<Evento> GetEventoAsync(int codEvento);
        Task<IList<ItemEvento>> GetEventosEmAltaAsync();
        Task<IList<ItemEvento>> GetEventosRecomendacaoAsync();
        Task<IList<ItemEvento>> GetEventosUltimasVisitasAsync();
        Task<IList<ItemEvento>> GetEventosSimilaresAsync(int codEvento);
    }
}