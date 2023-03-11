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

        [HttpGet("/zakljucaneGrupe")]
        public async Task<List<Grupa>> GetZakljucaneGrupe()
        {
            return await _grupaService.GetZakljucaneGrupe();
        }

        [HttpPost (Name = "DodajGrupu")]
        public async Task<IActionResult> AddGrupaAsync(GrupaDTO grupa)
        {
            await _grupaService.KreirajGrupu(grupa);
            return Ok();
        }


        [HttpPut(Name = "ZakljucajGrupu")]
        public async Task<IActionResult> ZakljucajGrupu(int grupaId)
        {
            await _grupaService.ZakljucajGrupu(grupaId);
            return Ok();
        }

        [HttpDelete(Name = "ObrisiGrupu")]
        public async Task<IActionResult> ObrisiGrupu(int grupaId)
        {
            await _grupaService.ObrisiGrupu(grupaId);
            return Ok();
        }

    }
}