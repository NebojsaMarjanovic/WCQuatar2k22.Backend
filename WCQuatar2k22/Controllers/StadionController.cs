using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCQuatar2k22.BusinessLogic;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.Interfaces;

namespace WCQuatar2k22.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StadionController : ControllerBase
    {
        IStadionService _stadionService;

        public StadionController(IStadionService stadionService)
        {
            _stadionService = stadionService;
        }

        [HttpGet(Name = "GetStadioni")]
        public async Task<List<Stadion>> GetAsync()
        {

            return await _stadionService.GetStadioni();
        }
        [HttpGet("{vremeOdrzavanja}")]
        public async Task<List<Stadion>> GetSlobodniStadioni(DateTime vremeOdrzavanja)
        {

            return await _stadionService.GetSlobodniStadioni(vremeOdrzavanja);
        }

    }
}
