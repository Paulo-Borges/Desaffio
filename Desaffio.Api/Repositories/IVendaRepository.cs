using Desaffio.Api.Models;

namespace Desaffio.Api.Repositories
{
    public interface IVendaRepository
    {
        Task<List<Venda>> ObterTodasAsync();
        Task AdicionarAsync(Venda venda);
    }
}
