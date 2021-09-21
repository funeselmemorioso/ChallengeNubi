using ChallengeNubi.Business.MELI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNubi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedasController : Controller
    {
        private readonly IBusquedasBusiness _productosBusiness;

        public BusquedasController(IBusquedasBusiness productosBusiness)
        {
            _productosBusiness = productosBusiness;
        }

        [Route("termino/{buscar}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] String buscar)
        {
            try
            {
                JObject OBJjson = await _productosBusiness.Buscar(buscar);
                return Ok(JsonConvert.SerializeObject(OBJjson));               
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
