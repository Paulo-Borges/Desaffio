using Desaffio.Api.Models;
using Desaffio.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desaffio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IVendaServices _vendaServices;
        public VendasController(IVendaServices vendaServices)
        {
            _vendaServices = vendaServices;
        }
        
        [HttpPost]
        public async Task<IActionResult> AdicionarVenda([FromBody] Venda venda)
        {
            try
            {
                await _vendaServices.AdicionarVendaAsync(venda);
                return Created("", venda);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("comissoes")]
        public async Task<IActionResult> ObterComissoes()
        {
            var comissoes = await _vendaServices.ObterComissoesAsync();
            return Ok(comissoes);
        }
    }
}
