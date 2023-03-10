using WCQuatar2k22.BusinessLogic.Models;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.Interfaces;
using WCQuatar2k22.Repository.UnitOfWork;

namespace WCQuatar2k22.BusinessLogic
{
    public class GrupaService:IGrupaService
    {
        private readonly IUnitOfWork _unitOfWork;


        public GrupaService(IUnitOfWork unitOfWork)
        {  
            _unitOfWork = unitOfWork;
        }
        public async Task KreirajGrupu(GrupaDTO grupaDTO)
        {
            Grupa grupa = new Grupa() { NazivGrupe = grupaDTO.NazivGrupe };
            int grupaId = await _unitOfWork.GrupaRepository.Add(grupa);
            foreach (var drzava in grupaDTO.Drzave)
            {
                await _unitOfWork.DrzavaRepository.UpdateGrupa(drzava.DrzavaId,grupaId);
            }
            await _unitOfWork.Save();
        }

        public async Task<List<Grupa>> GetGrupe()
        {
            return await _unitOfWork.GrupaRepository.GetAll();
        }

        public async Task<List<Grupa>> GetZakljucaneGrupe()
        {
            return await _unitOfWork.GrupaRepository.SearchBy(x => x.JeZakljucana == true);
        }

        public async Task ObrisiGrupu(int grupaId)
        {
            var drzave = await _unitOfWork.DrzavaRepository.SearchBy(x => x.GrupaId == grupaId);
            foreach (var drzava in drzave)
            {
                drzava.GrupaId = null;
                await _unitOfWork.DrzavaRepository.Update(drzava);
            }

            await _unitOfWork.GrupaRepository.Delete(grupaId);
            await _unitOfWork.Save();
        }

        public async Task ZakljucajGrupu(int grupaId)
        {
            await _unitOfWork.GrupaRepository.ZakljucajGrupu(grupaId);

            await _unitOfWork.Save();
        }
    }
}