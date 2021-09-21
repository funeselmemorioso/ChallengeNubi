using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Business.MELI.Interfaces
{
    public interface IBusquedasBusiness
    {
        Task<JObject> Buscar(String termino);
    }
}
