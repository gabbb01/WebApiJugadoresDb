using ApiJugadoresDb.Entities;
using ApiJugadoresDb.Features.Jugadores.Interfaces;
using ApiJugadoresDb.Infrastructure.Interfaces;

namespace ApiJugadoresDb.Features.Jugadores.AppServices
{
    public class PosicionesAppService : IPosicionesAppService
    {
        public readonly IPosicionesRepository posicionesRepository;
        public PosicionesAppService(IPosicionesRepository posicionesRepository)
        {
            this.posicionesRepository = posicionesRepository;
        }
        public async Task AgregarPosicion(Posicion posicion)
        {
            await posicionesRepository.AgregarPosicion(posicion);
        }

        public async Task<List<Posicion>> ObtenerPosiciones()
        {
            return await posicionesRepository.ObtenerPosiciones();
        }
    }
}
