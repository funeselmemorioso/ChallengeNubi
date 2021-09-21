using ChallengeNubi.Domain.Models.MELI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Business.MELI.Interfaces
{
    public interface ICurrenciesBusiness
    {     
        Task<bool> Guardar();
    }
}
