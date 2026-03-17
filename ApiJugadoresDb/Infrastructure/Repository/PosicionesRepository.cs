using ApiJugadoresDb.Entities;
using ApiJugadoresDb.Infrastructure.Databases;
using ApiJugadoresDb.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiJugadoresDb.Infrastructure.Repository
{
    public class PosicionesRepository : IPosicionesRepository
    {
        private readonly JugadoresDbContext jugadoresDbContext;
        public PosicionesRepository(JugadoresDbContext jugadoresDbContext)
        {
            this.jugadoresDbContext = jugadoresDbContext;
        }

        public async Task AgregarPosicion(Posicion posicion)
        {
            await jugadoresDbContext.Posiciones.AddAsync(posicion);
            await jugadoresDbContext.SaveChangesAsync();
        }

        public async Task<List<Posicion>> ObtenerPosiciones()
        {
            return await jugadoresDbContext.Posiciones.ToListAsync();
        }
    }
}
