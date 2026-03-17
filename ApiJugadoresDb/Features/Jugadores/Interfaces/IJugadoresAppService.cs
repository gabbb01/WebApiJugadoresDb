using ApiJugadoresDb.Commons.Models;
using ApiJugadoresDb.Entities;

namespace ApiJugadoresDb.Features.Jugadores.Interfaces
{
    public interface IJugadoresAppService
    {
        Task<List<Jugador>> ObtenerJugadores();
        Task<ApiResponse<Jugador>> AgregarJugador(Jugador jugador);
        Task<ApiResponse<Jugador>> ActualizarJugador(Jugador jugador);
        Task<Jugador> ObtenerJugadorPorId(int id);
        Task InactivarJugador(int id);
    }
}
