using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.Interfaces;
using WCQuatar2k22.Repository.UnitOfWork;

namespace WCQuatar2k22.BusinessLogic
{
    public class DrzavaService:IDrzavaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrzavaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public async Task<List<Drzava>> GetDrzave()
        {
            return await _unitOfWork.DrzavaRepository.GetAll();
        }

        public async Task<List<Drzava>> GetRaspoloziveDrzave(DateTime vremeOdrzavanja, int grupaId)
        {
            var utakmiceUToku = await _unitOfWork.UtakmicaRepository.SearchBy(x => x.VremeOdrzavanja <= vremeOdrzavanja && x.VremeOdrzavanja.AddHours(2) >= vremeOdrzavanja);
            var zauzeteDrzave = new List<Drzava>();

            foreach (var utakmica in utakmiceUToku)
            {
                zauzeteDrzave.Add(utakmica.Gost);
                zauzeteDrzave.Add(utakmica.Domacin);
            }

            //zauzeteDrzave = zauzeteDrzave.Where(x => x.GrupaId == grupaId).ToList();

            var slobodneDrzave = (await _unitOfWork.DrzavaRepository.SearchBy(x=>x.GrupaId==grupaId)).Except(zauzeteDrzave).ToList();

            return slobodneDrzave;
        }

        public async Task IzmeniDrzaveUGrupi(int grupaId, int staraDrzava, int novaDrzava)
        {
          
            await _unitOfWork.DrzavaRepository.IzmeniDrzaveUGrupi(grupaId, staraDrzava, novaDrzava);
            await _unitOfWork.Save();

        }
    }
}
