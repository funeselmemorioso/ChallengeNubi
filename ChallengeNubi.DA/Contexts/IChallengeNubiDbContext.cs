using ChallengeNubi.Domain.Models;
using ChallengeNubi.Domain.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.DA.Contexts
{
    public interface IChallengeNubiDbContext
    {
        DbSet<Usuario> Usuarios { get; set; }
        void Commit();
        Task CommitAsync();
        Task Dispose();       
    }
}
