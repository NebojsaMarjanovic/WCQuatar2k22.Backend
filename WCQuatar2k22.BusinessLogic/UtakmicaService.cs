using WCQuatar2k22.BusinessLogic.Enumerations;
using WCQuatar2k22.BusinessLogic.Models;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.UnitOfWork;

namespace WCQuatar2k22.BusinessLogic
{
    public class UtakmicaService : IUtakmicaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UtakmicaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseStatus> AddUtakmica(UtakmicaDTO utakmicaDTO)
        {
            var sveUtakmice = await _unitOfWork.UtakmicaRepository.GetAll();

            foreach (var item in sveUtakmice)
            {
                if((utakmicaDTO.GostId==item.GostId || utakmicaDTO.GostId==item.DomacinId) && (utakmicaDTO.DomacinId==item.DomacinId || utakmicaDTO.DomacinId == item.GostId))
                {
                    return ResponseStatus.BadRequest;
                }
            }

            Utakmica utakmica = new Utakmica()
            {
                DomacinId = utakmicaDTO.DomacinId,
                GostId = utakmicaDTO.GostId,
                VremeOdrzavanja = utakmicaDTO.VremeOdrzavanja,
                StadionId = utakmicaDTO.StadionId
            };

            int utakmicaId = await _unitOfWork.UtakmicaRepository.Add(utakmica);

            await _unitOfWork.Save();
            return ResponseStatus.Ok;
        }

        public async Task<List<Utakmica>> GetUtakmice()
        {
            return await _unitOfWork.UtakmicaRepository.GetAll();
        }

        public async Task<ResponseStatus> DodajRezultat (int utakmicaId, int rezultatDomacin, int rezultatGost)
        {
            try
            {
                var utakmica = await _unitOfWork.UtakmicaRepository.SearchById(utakmicaId);
                  
                    await _unitOfWork.UtakmicaRepository.UpdateRezultat(utakmicaId, rezultatDomacin, rezultatGost);
                    await _unitOfWork.Save();

                    await UpdateBodovi(utakmica, rezultatDomacin, rezultatGost);

                    await _unitOfWork.Save();
                    return ResponseStatus.Ok;
                    
            }
            catch (Exception)
            {
                return ResponseStatus.TransientError;
            }            
        }

        public async Task UpdateBodovi(Utakmica utakmica, int rezultatDomacin, int rezultatGost)
        {
            int bodoviDomacin = 0;
            int bodoviGost = 0;

            if (rezultatDomacin > rezultatGost)
                bodoviDomacin = 3;
            else if (rezultatGost > rezultatDomacin)
                bodoviGost = 3;
            else
                bodoviGost = bodoviDomacin = 1;

            await _unitOfWork.DrzavaRepository.UpdateBodovi(utakmica.DomacinId, rezultatDomacin, rezultatGost, bodoviDomacin);
            await _unitOfWork.DrzavaRepository.UpdateBodovi(utakmica.GostId,rezultatGost, rezultatDomacin, bodoviGost);
        }
    }
}
