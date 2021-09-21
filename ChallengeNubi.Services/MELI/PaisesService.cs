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
    public class PaisesService : IPaisesService
    {
        private readonly string _uriApiMELI = "";

        public PaisesService(IConfiguration configuration)
        {
            _uriApiMELI = configuration.GetSection("APIS").GetSection("MELI").Value;
        }

        public async Task<List<Pais>> GetAll()
        {            
            String url = _uriApiMELI + "/classified_locations/countries/";

            try
            {
                var request = await url.GetJsonAsync<List<Pais>>();
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Pais> GetById(String id) 
        {
            String url = _uriApiMELI + "/classified_locations/countries/" + id;

            try
            {
                var request = await url.GetJsonAsync<Pais>();
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
