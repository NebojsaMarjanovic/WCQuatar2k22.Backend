using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WCQuatar2k22.BusinessLogic;
using WCQuatar2k22.BusinessLogic.Enumerations;
using WCQuatar2k22.BusinessLogic.Models;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Models;

namespace WCQuatar2k22.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UtakmicaController : ControllerBase
    {
        private readonly IUtakmicaService _utakmicaService;

        public UtakmicaController(IUtakmicaService utakmicaService)
        {
            _utakmicaService = utakmicaService;
        }

        [HttpPost(Name = "ZakaziUtakmicu")]
        public async Task<IActionResult> AddUtakmica(UtakmicaDTO utakmica)
        {
            switch(await _utakmicaService.ZakaziUtakmicu(utakmica))
            {
                case ResponseStatus.Ok:
                    return StatusCode(StatusCodes.Status200OK, new Response { Status="Success", Message="Utakmica je uspešno zakazana!"});
                case ResponseStatus.BadRequest:
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Utakmica izmedju unetih država se već nalazi u sistemu." });
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Serverska greška!" });
            }
        }

        [HttpGet(Name = "GetUtakmice")]
        public async Task<List<Utakmica>> GetUtakmice()
        {

            return await _utakmicaService.GetUtakmice();
        }

        [HttpGet("{datumUtakmice}")]
        public async Task<List<Utakmica>> GetUtakmicePoDatumu(DateTime datumUtakmice)
        {

            return await _utakmicaService.GetUtakmicePoDatumu(datumUtakmice);
        }



        [HttpPut("{utakmicaId}-{domacinRezultat}-{gostRezultat}")]
        public async Task<IActionResult> UpdateRezultat(int utakmicaId, int domacinRezultat, int gostRezultat)
        {

            switch(await _utakmicaService.DodajRezultat(utakmicaId, domacinRezultat, gostRezultat))
            {
                case ResponseStatus.Ok:
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Uspešno ste uneli rezultat!" });
                case ResponseStatus.BadRequest:
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Nije moguće uneti rezultat za utakmicu koja se još nije odigrala!" });
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Serverska greška!" });
            }
        }


    }
}
