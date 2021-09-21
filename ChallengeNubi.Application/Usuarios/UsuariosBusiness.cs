using ChallengeNubi.Business.Usuarios.Interfaces;
using ChallengeNubi.DA.Repositories;
using ChallengeNubi.Domain.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Business.Usuarios
{
    public class UsuariosBusiness : IUsuariosBusiness
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosBusiness(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<List<Usuario>> Get()
        {
            return await _usuariosRepository.Get();           
        }

        public async Task<Usuario> GetByID(int id)
        {
            return await _usuariosRepository.GetByID(id);           
        }

        public async Task<Usuario> Insert(Usuario u)
        {
            u.Id = 0;
            Usuario us = await _usuariosRepository.Insert(u);
            await _usuariosRepository.Save();
            return us;
        }

        public async Task<Usuario> Delete(int id)
        {
            Usuario u = await _usuariosRepository.Delete(id);
            await _usuariosRepository.Save();
            return u;
        }

        public async Task<Usuario> Update(Usuario u)
        {
            Usuario us = await _usuariosRepository.Update(u);
            await _usuariosRepository.Save(); 
            return us;
        }
    }
}
