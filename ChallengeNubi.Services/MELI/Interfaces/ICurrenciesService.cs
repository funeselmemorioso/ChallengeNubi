using ChallengeNubi.Domain.Models.MELI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Services.MELI.Interfaces
{
    public interface ICurrenciesService
    {
        Task<List<Currency>> Listar();
        Task<CurrencyConversion> Convertir(String de, String a);
    }
}
