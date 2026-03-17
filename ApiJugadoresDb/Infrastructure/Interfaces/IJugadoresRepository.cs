using ApiJugadoresDb.Entities;

namespace ApiJugadoresDb.Infrastructure.Interfaces
{
    public interface IJugadoresRepository
    {
        Task<List<Jugador>> ObtenerJugadores();
        Task<Jugador> ObtenerJugadorPorId(int id);
        Task AgregarJugador(Jugador jugador);
        Task ActualizarJugador(Jugador jugador);
        Task EliminarJugador(int id);
    }
}
