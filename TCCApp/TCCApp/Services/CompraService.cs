using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Models.TO;
using TCCApi.CrudApi.Models;
using Xamarin.Forms;

namespace TCCApp.Services
{
    public class CompraService : ICompraService
    {

        public IServiceHelper Helper { get; }
        public CompraService()
        {
            Helper = DependencyService.Get<IServiceHelper>();
        }

        public async Task<Compra> GetCompraAsync(int codCompra)
        {
            var response = await Helper.GetAsync("/Compra/" + codCompra);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<Compra>(json);

            return lista;
        }

        public async Task<IList<ItemCompra>> GetComprasAsync()
        {
            var response = await Helper.GetAsync("/Compra/Usuario");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<List<ItemCompra>>(json);

            return lista;
        }

        public async Task<Compra> PostCompraAsync(int codCompra)
        {
            var response = await Helper.GetAsync("/Compra/" + codCompra);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao consultar Servidor" + response.RequestMessage);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<Compra>(json);

            return lista;
        }
    }
}
