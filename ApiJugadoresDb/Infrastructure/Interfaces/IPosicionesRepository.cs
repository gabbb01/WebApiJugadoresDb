using ApiJugadoresDb.Entities;

namespace ApiJugadoresDb.Infrastructure.Interfaces
{
    public interface IPosicionesRepository
    {
        Task<List<Posicion>> ObtenerPosiciones();
        Task AgregarPosicion(Posicion posicion);
    }
}
