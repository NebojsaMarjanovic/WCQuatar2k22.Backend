using Microsoft.AspNetCore.Mvc;
using WCQuatar2k22.BusinessLogic;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.Interfaces;

namespace WCQuatar2k22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrzavaController : ControllerBase
    {
        private readonly IDrzavaService _drzavaService;

        public DrzavaController(IDrzavaService drzavaService)
        {
            _drzavaService = drzavaService;
        }

        [HttpGet(Name = "GetNerasporedjeneDrzave")]
        public async Task<List<Drzava>> GetAsync()
        {

            return await _drzavaService.GetNerasporedjeneDrzave();
        }

        [HttpGet("{grupaId}/{vremeOdrzavanja}")]
        public async Task<List<Drzava>> GetSlobodneDrzave(DateTime vremeOdrzavanja, int grupaId)
        {

            return await _drzavaService.GetRaspoloziveDrzave(vremeOdrzavanja,grupaId);
        }

        [HttpPut("{grupaId}-{staraDrzava}-{novaDrzava}")]
        public async Task IzmeniDrzaveUGrupi(int grupaId, int staraDrzava, int novaDrzava)
        {
            await _drzavaService.IzmeniDrzaveUGrupi(grupaId, staraDrzava, novaDrzava);
        }

    }
}