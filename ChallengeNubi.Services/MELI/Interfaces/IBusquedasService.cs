using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Services.MELI.Interfaces
{
    public interface IBusquedasService
    {
        Task<String> Buscar(String termino);
    }
}
