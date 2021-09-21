using ChallengeNubi.Services.MELI.Interfaces;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ChallengeNubi.Services.MELI
{
    public class BusquedasService : IBusquedasService
    {
        private readonly string _uriApiMELI = "";

        public BusquedasService(IConfiguration configuration)
        {
            _uriApiMELI = configuration.GetSection("APIS").GetSection("MELI").Value;
        }

        public async Task<String> Buscar(String termino)
        {
            String url = _uriApiMELI + "/sites/MLA/search?q=" + termino;

            try
            {                
                var request = await url.GetStringAsync();             
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
