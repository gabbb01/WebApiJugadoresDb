using ApiJugadoresDb.Commons.Models;
using ApiJugadoresDb.Entities;

namespace ApiJugadoresDb.Features.Jugadores.Interfaces
{
    public interface IPosicionesAppService
    {
        Task<List<Posicion>> ObtenerPosiciones();
        Task<ApiResponse<Posicion>> AgregarPosicion(Posicion posicion);
    }
}
