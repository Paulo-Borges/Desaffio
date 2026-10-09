using Desaffio.Api.Models;

namespace Desaffio.Api.Services
{
    public interface IVendaServices
    {
        Task AdicionarVendaAsync(Venda venda);
        Task<List<ComissaoResponse>> ObterComissoesAsync();
        
    }
}
