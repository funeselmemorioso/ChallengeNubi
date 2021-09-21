using ChallengeNubi.Business.MELI.Interfaces;
using ChallengeNubi.Services.MELI.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Business.MELI
{
    public class BusquedasBusiness : IBusquedasBusiness
    {
        private readonly IBusquedasService _busquedasService;

        public BusquedasBusiness(IBusquedasService busquedasService)
        {
            _busquedasService = busquedasService;
        }

        public async Task<JObject> Buscar(String termino)
        {
            try
            {
                String STRjson = await _busquedasService.Buscar(termino);
                JObject OBJjson = JObject.Parse(STRjson);
                List<String> propiedadesDeResult = new List<string>() { "id" , "site_id", "title", "price", "seller.id", "permalink" };

                var props = OBJjson["results"][0].Select(x => ((JProperty)x).Name).ToList();

                foreach (var p in props)
                {
                    if (!propiedadesDeResult.Contains(p))
                    {
                        OBJjson.SelectToken("results." + p)?.Parent.Remove();
                    }
                }

                return OBJjson;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
