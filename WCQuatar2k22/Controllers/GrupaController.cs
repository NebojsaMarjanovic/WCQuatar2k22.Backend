using Microsoft.AspNetCore.Mvc;
using WCQuatar2k22.BusinessLogic;
using WCQuatar2k22.BusinessLogic.Models;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupaController : ControllerBase
    {
        private readonly IGrupaService _grupaService;

    

        public GrupaController(IGrupaService grupaService)
        {
            _grupaService = grupaService;
        }

        [HttpGet(Name = "GetGrupe")]
        public async Task<List<Grupa>> GetAsync()
        {
            return await _grupaService.GetGrupe();
        }

        [HttpPost (Name = "DodajGrupu")]
        public async Task<IActionResult> AddGrupaAsync(GrupaDTO grupa)
        {
            await _grupaService.DodajGrupu(grupa);
            return Ok();
        }
    }
}