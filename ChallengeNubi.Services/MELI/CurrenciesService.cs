using ChallengeNubi.Domain.Models.MELI;
using ChallengeNubi.Services.MELI.Interfaces;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Services.MELI
{
    public class CurrenciesService : ICurrenciesService
    {
        private readonly string _uriApiMELI = "";

        public CurrenciesService(IConfiguration configuration)
        {
            _uriApiMELI = configuration.GetSection("APIS").GetSection("MELI").Value;
        }

        public async Task<List<Currency>> Listar()
        {
            String url = _uriApiMELI + "/currencies/";

            try
            {
                var request = await url.GetJsonAsync<List<Currency>>();
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CurrencyConversion> Convertir(String de, String a)
        {
            String url = _uriApiMELI + "/currency_conversions/search?from="+ de + "&to=" + a;

            try
            {
                var request = await url.GetJsonAsync<CurrencyConversion>();
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
