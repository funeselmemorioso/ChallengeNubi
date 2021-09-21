using ChallengeNubi.Business.Usuarios.Interfaces;
using ChallengeNubi.Domain.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeNubi.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosBusiness _usuariosBusiness;

        public UsuariosController(IUsuariosBusiness usuariosBusiness)
        {
            _usuariosBusiness = usuariosBusiness;
        }

        [Route("usuarios")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Usuario> u = await _usuariosBusiness.Get();
            return Ok(u);
        }

        [Route("usuarios/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            Usuario u = await _usuariosBusiness.GetByID(id);
            return Ok(u);
        }

        [Route("usuarios")]
        [HttpPost]
        public async Task<IActionResult> Insert(Usuario u)
        {            
            Usuario r = await _usuariosBusiness.Insert(u);
            return Ok(r);
        }

        [Route("usuarios/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Usuario r = await _usuariosBusiness.Delete(id);
            return Ok(r);
        }

        [Route("usuarios")]
        [HttpPut]
        public async Task<IActionResult> Update(Usuario u)
        {
            Usuario r = await _usuariosBusiness.Update(u);
            return Ok(r);
        }
    }
}
