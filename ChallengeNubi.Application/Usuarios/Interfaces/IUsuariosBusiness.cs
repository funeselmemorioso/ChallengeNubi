using ChallengeNubi.Domain.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Business.Usuarios.Interfaces
{
    public interface  IUsuariosBusiness
    {
        Task<List<Usuario>> Get();
        Task<Usuario> GetByID(int id);
        Task<Usuario> Insert(Usuario u);
        Task<Usuario> Delete(int id);
        Task<Usuario> Update(Usuario u);
    }
}
