using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.UnitOfWork;

namespace WCQuatar2k22.BusinessLogic
{
    public class StadionService : IStadionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StadionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Stadion>> GetSlobodniStadioni(DateTime vremeOdrzavanja)
        {
            var utakmiceUToku = await _unitOfWork.UtakmicaRepository.SearchBy(x => x.VremeOdrzavanja <= vremeOdrzavanja && x.VremeOdrzavanja.AddHours(2) >= vremeOdrzavanja);
            var zauzetiStadioni = new List<Stadion>();

            foreach (var utakmica in utakmiceUToku)
            {
                zauzetiStadioni.Add(utakmica.Stadion);
            }

            var slobodniStadioni = (await _unitOfWork.StadionRepository.GetAll()).Except(zauzetiStadioni).ToList();

            return slobodniStadioni;
        }

        public Task<List<Stadion>> GetStadioni()
        {
            return _unitOfWork.StadionRepository.GetAll();
        }
    }
}
