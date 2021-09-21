using ChallengeNubi.Domain.Models;
using ChallengeNubi.Domain.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.DA.Contexts
{
    public class ChallengeNubiDbContext : DbContext, IChallengeNubiDbContext
    {    
        public DbSet<Usuario> Usuarios { get; set; }
        

        public ChallengeNubiDbContext(DbContextOptions<ChallengeNubiDbContext> options) : base(options)
        {
            
        }       

        public void Commit()
        {
            SaveChanges();
        }

        public Task CommitAsync()
        {
           
            return SaveChangesAsync();
        }

        public async Task Dispose()
        {
           await DisposeAsync();
        }

        
    }
}
