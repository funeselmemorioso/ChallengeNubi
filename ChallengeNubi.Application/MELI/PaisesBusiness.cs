using ChallengeNubi.Business.MELI.Interfaces;
using ChallengeNubi.Domain.Models.MELI;
using ChallengeNubi.Services.MELI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeNubi.Business.MELI
{
    public class PaisesBusiness : IPaisesBusiness
    {
        private readonly IPaisesService _paisesService;

        public PaisesBusiness(IPaisesService paisesService)
        {
            _paisesService = paisesService;
        }

        public async Task<List<Pais>> GetAll()
        {            
            try
            {
                List <Pais> p = await _paisesService.GetAll();
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Pais> GetById(String id)
        {      
            try
            {
                Pais p = await _paisesService.GetById(id);
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
