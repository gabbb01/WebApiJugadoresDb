using ApiJugadoresDb.Entities;

namespace ApiJugadoresDb.Features.Jugadores.Interfaces
{
    public interface IPosicionesAppService
    {
        Task<List<Posicion>> ObtenerPosiciones();
        Task AgregarPosicion(Posicion posicion);
    }
}
