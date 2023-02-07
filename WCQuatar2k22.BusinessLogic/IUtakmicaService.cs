using WCQuatar2k22.BusinessLogic.Enumerations;
using WCQuatar2k22.BusinessLogic.Models;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.BusinessLogic
{
    public interface IUtakmicaService
    {
        Task<List<Utakmica>> GetUtakmice();
        Task<ResponseStatus> AddUtakmica(UtakmicaDTO utakmicaDTO);

        Task<ResponseStatus> DodajRezultat(int utakmicaId, int rezultatDomacin, int rezultatGost);
    }
}
