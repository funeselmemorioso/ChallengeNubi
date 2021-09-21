using ChallengeNubi.Domain.Models.MELI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Services.MELI.Interfaces
{
    public interface IPaisesService
    {
        Task<List<Pais>> GetAll();
        Task<Pais> GetById(String id);
    }
}
