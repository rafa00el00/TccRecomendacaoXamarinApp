using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Models.TO;
using TCCApi.CrudApi.Models;

namespace TCCApp.Services
{
    public interface ICompraService
    {
        IServiceHelper Helper { get; }

        Task<Compra> GetCompraAsync(int codCompra);
        Task<IList<ItemCompra>> GetComprasAsync();
        Task<Compra> PostCompraAsync(int codCompra);
    }
}