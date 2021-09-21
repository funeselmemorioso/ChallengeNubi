using ChallengeNubi.Domain.Models.MELI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Business.MELI.Interfaces
{
    public interface IPaisesBusiness
    {
        Task<Pais> GetById(String id);
        Task<List<Pais>> GetAll();
    }
}
