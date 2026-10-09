using Desaffio.Api.Models;
using System.Text.Json;

namespace Desaffio.Api.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly string _arquivo; 
        public VendaRepository()
        {
            _arquivo = Path.Combine(
                Directory.GetCurrentDirectory(), "Data", "Venda.json");
        }
        public async Task AdicionarAsync(Venda venda)
        {
            var vendas = await ObterTodasAsync();
            vendas.Add(venda);
            var json = JsonSerializer.Serialize(
            vendas,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await File.WriteAllTextAsync(_arquivo, json);
        }

        public async Task<List<Venda>> ObterTodasAsync()
        {
            if(!File.Exists(_arquivo))
            {
                return new List<Venda>();
            }

            var json = await File.ReadAllTextAsync(_arquivo);
            Console.WriteLine(json);

            return JsonSerializer.Deserialize<List<Venda>>(json) ?? new List<Venda>();

        }
    }
}
