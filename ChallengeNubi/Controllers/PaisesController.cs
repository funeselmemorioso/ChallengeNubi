using ChallengeNubi.Business.MELI;
using ChallengeNubi.Business.MELI.Interfaces;
using ChallengeNubi.Domain.Enums;
using ChallengeNubi.Domain.Models.MELI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNubi.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesBusiness _paisesBusiness;

        public PaisesController(IPaisesBusiness paisesBusiness)
        {
            _paisesBusiness = paisesBusiness;
        }

        [Route("paises/{id}")]
        [HttpGet]       
        public async Task<IActionResult> GetById(String id)
        {
            try
            {
                if(Enum.IsDefined(typeof(PaisesAutorizados), id))
                {
                    Pais p = await _paisesBusiness.GetById(id);
                    return Ok(p);
                }
                return Unauthorized();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
