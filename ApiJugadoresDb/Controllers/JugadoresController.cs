using ApiJugadoresDb.Entities;
using ApiJugadoresDb.Features.Jugadores.Interfaces;
using ApiJugadoresDb.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiJugadoresDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly IJugadoresAppService jugadoresAppService;
        public JugadoresController(IJugadoresAppService jugadoresAppService)
        {
            this.jugadoresAppService = jugadoresAppService;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerJugadores()
        {
            List<Jugador> jugadores = await jugadoresAppService.ObtenerJugadores();
            return Ok(jugadores);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerJugadorPorId([FromRoute] int id)
        {
            Jugador jugador = await jugadoresAppService.ObtenerJugadorPorId(id);
            return Ok(jugador);
        }
        [HttpPost]
        public async Task <IActionResult> AgregarJugador([FromBody] Jugador jugador)
        {
            var respuesta = await jugadoresAppService.AgregarJugador(jugador);
            return Ok(respuesta);
        }
        [HttpPut]
        public async Task< IActionResult> ActualizarJugador([FromBody] Jugador jugador)
        {
            var respuesta = await jugadoresAppService.ActualizarJugador(jugador);
            return Ok(respuesta);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> InactivarJugador([FromRoute] int id)
        {
            await jugadoresAppService.InactivarJugador(id);
            return Ok("Registro inactivado");
        }
    }
}
