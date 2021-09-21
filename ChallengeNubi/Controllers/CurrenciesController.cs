using ChallengeNubi.Business.MELI.Interfaces;
using ChallengeNubi.Domain.Models.MELI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNubi.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly ICurrenciesBusiness _currenciesBusiness;

        public CurrenciesController(ICurrenciesBusiness currenciesBusiness)
        {
            _currenciesBusiness = currenciesBusiness;
        }

        [Route("guardar")]
        [HttpGet]
        public async Task<IActionResult> Guardar()
        {
            try
            {
                await _currenciesBusiness.Guardar();               
                return Ok();                              
            }
            catch (Exception e)
            {
                throw e;
            }
        }       
    }
}
