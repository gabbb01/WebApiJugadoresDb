using ApiJugadoresDb.Entities;
using ApiJugadoresDb.Infrastructure.Databases;
using ApiJugadoresDb.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiJugadoresDb.Infrastructure.Repository
{
    public class JugadoresRepository : IJugadoresRepository
    {
        private readonly JugadoresDbContext jugadoresDbContext;
        public JugadoresRepository(JugadoresDbContext jugadoresDbContext)
        {
            this.jugadoresDbContext = jugadoresDbContext;
        }

        public async Task ActualizarJugador(Jugador jugador)
        {
            Jugador jugadorExistente = 
                jugadoresDbContext.Jugadores
                .FirstOrDefault(x => x.Id == jugador.Id)!;

            jugadorExistente.Nombre = jugador.Nombre;
            jugadorExistente.Equipo = jugador.Equipo;
            jugadorExistente.NumeroCamisa = jugador.NumeroCamisa;
            jugadorExistente.Activo = jugador.Activo;

            await jugadoresDbContext.SaveChangesAsync();

        }

        public async Task AgregarJugador(Jugador jugador)
        {
            jugadoresDbContext.Jugadores.Add(jugador);
            await jugadoresDbContext.SaveChangesAsync();
        }

        public async Task EliminarJugador(int id)
        {
            Jugador jugadorExistente =
            jugadoresDbContext.Jugadores
            .FirstOrDefault(x => x.Id == id)!;

            jugadorExistente.Activo = false;
            await jugadoresDbContext.SaveChangesAsync();
        }

        public async Task<List<Jugador>> ObtenerJugadores()
        {
            return await jugadoresDbContext.Jugadores.ToListAsync();
            throw new NotImplementedException();
        }


        public async Task<Jugador> ObtenerJugadorPorId(int id)
        {
            Jugador? jugador =
                await jugadoresDbContext.Jugadores.FirstOrDefaultAsync(x => x.Id == id);
            return jugador ?? new Jugador();
        }
    }
}
