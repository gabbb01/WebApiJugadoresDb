using ApiJugadoresDb.Entities;
using ApiJugadoresDb.Features.Jugadores.AppServices;
using ApiJugadoresDb.Features.Jugadores.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiJugadoresDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionesController : ControllerBase
    {
        private readonly IPosicionesAppService posicionesAppService;
        public PosicionesController(IPosicionesAppService posicionesAppService)
        {
            this.posicionesAppService = posicionesAppService;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerPosiciones()
        {
            List<Posicion> posiciones = await posicionesAppService.ObtenerPosiciones();
            return Ok(posiciones);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarPosicion([FromBody] Posicion posicion)
        {
            var respuesta = await posicionesAppService.AgregarPosicion(posicion);
            return Ok(respuesta);
        }
    }
}
