using Desaffio.Api.Models;
using Desaffio.Api.Repositories;

namespace Desaffio.Api.Services
{
    public class VendaServices : IVendaServices
    {
        private readonly IComissaoService _comissaoService;
        private readonly IVendaRepository _vendaRepository;
        public VendaServices(IComissaoService comissaoService, IVendaRepository vendaRepository)
        {
            _comissaoService = comissaoService;
            _vendaRepository = vendaRepository;
        }
        public async Task AdicionarVendaAsync(Venda venda)
        {
            if(venda.Valor <= 0)
                throw new ArgumentException("O valor da venda deve ser maior que zero.");
            await _vendaRepository.AdicionarAsync(venda);
        }

        public async Task<List<ComissaoResponse>> ObterComissoesAsync()
        {
            var vendas = await _vendaRepository.ObterTodasAsync();
            
            return vendas.GroupBy(v => v.Vendedor)
                         .Select(g => new ComissaoResponse
                         {
                             Vendedor = g.Key,
                             Comissao = g.Sum(v => _comissaoService.Calcular(v.Valor))
                         })
                         .ToList(); 
        }
    }
}
