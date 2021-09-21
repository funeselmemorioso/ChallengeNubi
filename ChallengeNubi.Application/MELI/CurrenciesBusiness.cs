using ChallengeNubi.Business.MELI.Interfaces;
using ChallengeNubi.Common.Utils;
using ChallengeNubi.Domain.DTOs;
using ChallengeNubi.Domain.Models.MELI;
using ChallengeNubi.Services.MELI.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ChallengeNubi.Business.MELI
{
    public class CurrenciesBusiness : ICurrenciesBusiness
    {
        private readonly ICurrenciesService _currenciesService;
        private readonly IArchivosHandler _archivosHandler;
        private readonly String _pathGuardarAchivos;

        public CurrenciesBusiness(ICurrenciesService currenciesService, 
                                  IArchivosHandler archivosHandler,
                                  IConfiguration configuration)
        {
            _currenciesService = currenciesService;
            _archivosHandler = archivosHandler;
            _pathGuardarAchivos = configuration.GetSection("Paths").GetSection("GuardarArchivos").Value;
        }        

        public async Task<bool> Guardar()
        {
            try
            {
                List<Currency> currencies = await _currenciesService.Listar();
                List<CurrencyDTO> currenciesConDolar = new List<CurrencyDTO>();
                String JsonCurrenciesConDolar = String.Empty;
                String csvCurerncyConversions = String.Empty;

                foreach (Currency currency in currencies)
                {
                    try
                    {
                        double ratioConversion = (await _currenciesService.Convertir(currency.id, "USD")).ratio;
                        CurrencyDTO cDTO = new CurrencyDTO();                       
                        cDTO.id = currency.id;
                        cDTO.decimal_places = currency.decimal_places;
                        cDTO.description = currency.description;
                        cDTO.symbol = currency.symbol;
                        cDTO.toDolar = ratioConversion;

                        currenciesConDolar.Add(cDTO);
                        csvCurerncyConversions += ratioConversion.ToString().Replace(",", ".") + ",";
                    }
                    catch (Exception e)
                    {
                        // Se puede loguear si alguna dio error o hacer algo, pero continuado con las demás
                        continue;
                    }                    
                }

                JsonCurrenciesConDolar = JsonConvert.SerializeObject(currenciesConDolar);

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    _archivosHandler.GenerarJSON(JSON: JsonCurrenciesConDolar,
                                             path: _pathGuardarAchivos + "/JSON_CURRENCIES_" + DateTime.Now.ToString("MM_dd_HH_MM_ss"));

                    _archivosHandler.GenerarCSV(CSV: csvCurerncyConversions,
                                                path: _pathGuardarAchivos + "/CSV_CURRENCIES_" + DateTime.Now.ToString("MM_dd_HH_MM_ss"));
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
