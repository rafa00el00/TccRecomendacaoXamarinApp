using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.TO;
using static System.Net.WebRequestMethods;

namespace TCCApp.Services
{



    public class EventoService
    {
        public EventoService(ServiceHelper helper)
        {
            Helper = helper;
        }

        public ServiceHelper Helper { get; }

        public async Task<List<ItemEvento>> GetEventosMainAsync()
        {
            var response = await Helper.Get("/Evento/Main");

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
