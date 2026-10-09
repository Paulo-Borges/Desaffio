namespace Desaffio.Api.Services
{
    public class ComissaoService : IComissaoService
    {
        public decimal Calcular(decimal valorVenda)
        {
            if (valorVenda < 100)

                return 0;

            if (valorVenda < 500)

                return valorVenda * 0.01m;


            return valorVenda * 0.05m;

        }
    }
}
