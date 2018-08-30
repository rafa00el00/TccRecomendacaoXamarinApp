using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.TO;
using TCCApi.CrudApi.Models;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace TCCApp.Services
{

    public interface IEventoService
    {
        Task<IList<ItemEvento>> GetEventosRecomendacaoAsync();
        Task<IList<ItemEvento>> GetEventosEmAltaAsync();
        Task<IList<ItemEvento>> GetEventosUltimasVisitasAsync();
        Task<Evento> GetEventoAsync(int codEvento);
        Task<IList<ItemEvento>> GetEventoSimilaresAsync(int codEvento);
    }

    public class EventoService : IEventoService
    {
        public EventoService()
        {
            Helper = DependencyService.Get<IServiceHelper>();
        }

        public IServiceHelper Helper { get; }

        public async Task<Evento> GetEventoAsync(int codEvento)
        {
            var response = await Helper.GetAsync("/Evento/" + codEvento);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<Evento>(json);

            return lista;
        }

        public async Task<IList<ItemEvento>> GetEventosEmAltaAsync()
        {
            var response = await Helper.GetAsync("/Evento/EmAlta");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<ItemEvento>>(json);

            return lista;
        }

        public async Task<IList<ItemEvento>> GetEventoSimilaresAsync(int codEvento)
        {
            var response = await Helper.GetAsync("/Evento/Recomendado/" + codEvento);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<IList<ItemEvento>>(json);

            return lista;
        }

        public async Task<IList<ItemEvento>> GetEventosRecomendacaoAsync()
        {
            var response = await Helper.GetAsync("/Evento/Recomendacoes");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<ItemEvento>>(json);

            return lista;
        }

        public async Task<IList<ItemEvento>> GetEventosUltimasVisitasAsync()
        {
            var response = await Helper.GetAsync("/Evento/UltimosVisitados");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<ItemEvento>>(json);

            return lista;
        }

        
    }
}
