using ChallengeNubi.DA.Contexts;
using ChallengeNubi.Domain.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeNubi.DA.Repositories
{
    public class UsuariosRepository : IUsuariosRepository, IDisposable
    {
        private IChallengeNubiDbContext _challengeNubiDbContext;

        public UsuariosRepository(IChallengeNubiDbContext challengeNubiDbContext)
        {
            _challengeNubiDbContext = challengeNubiDbContext;
        }

        public async Task<List<Usuario>> Get()
        {
            List<Usuario> u = await _challengeNubiDbContext.Usuarios.ToListAsync();
            return u;
        }

        public async Task<Usuario> GetByID(int id)
        {
            Usuario u = await _challengeNubiDbContext.Usuarios.FirstOrDefaultAsync(x=>x.Id == id);
            return u;
        }

        public async Task<Usuario> Insert(Usuario u)
        {
            await _challengeNubiDbContext.Usuarios.AddAsync(u);            
            return u;
        }

        public async Task<Usuario> Delete(int id)
        {
            Usuario u = await _challengeNubiDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            _challengeNubiDbContext.Usuarios.Remove(u);
            return u;
        }       

        public async Task<Usuario> Update(Usuario u)
        {
            var editar = await _challengeNubiDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == u.Id);
            editar.Nombre = u.Nombre;
            editar.Apellido = u.Apellido;
            editar.EMail = u.EMail;
            editar.Password = u.Password;

            await _challengeNubiDbContext.CommitAsync();          
            return u;
        }

        public async Task Save()
        {
            await _challengeNubiDbContext.CommitAsync();
        }

        private bool disposed = false;

        protected async virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await _challengeNubiDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}