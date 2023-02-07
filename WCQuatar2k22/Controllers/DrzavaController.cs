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

        [HttpGet(Name = "GetDrzave")]
        public async Task<List<Drzava>> GetAsync()
        {

            return await _drzavaService.GetDrzave();
        }

        [HttpGet("{grupaId}/{vremeOdrzavanja}")]
        public async Task<List<Drzava>> GetSlobodneDrzave(DateTime vremeOdrzavanja, int grupaId)
        {

            return await _drzavaService.GetRaspoloziveDrzave(vremeOdrzavanja,grupaId);
        }
    }
}