using ApiJugadoresDb.Commons.Models;
using ApiJugadoresDb.Entities;
using ApiJugadoresDb.Features.Jugadores.DomainServices;
using ApiJugadoresDb.Features.Jugadores.Interfaces;
using ApiJugadoresDb.Infrastructure.Interfaces;
using ApiJugadoresDb.Infrastructure.Repository;

namespace ApiJugadoresDb.Features.Jugadores.AppServices
{
    public class JugadoresAppService: IJugadoresAppService
    {
        private readonly JugadoresDomainService jugadoresDomainService;
        private readonly IJugadoresRepository jugadoresRepository;
        private readonly IPosicionesRepository posicionesRepository;
        public JugadoresAppService(IJugadoresRepository jugadoresRepository, JugadoresDomainService jugadoresDomainService, IPosicionesRepository posicionesRepository)
        {
            this.jugadoresRepository = jugadoresRepository;
            this.jugadoresDomainService = jugadoresDomainService;
            this.posicionesRepository = posicionesRepository;
        }
        public async Task<ApiResponse<Jugador>> ActualizarJugador(Jugador jugador)
        {
            ApiResponse<Jugador> apiResponseResult =
                jugadoresDomainService.AgregarJugador(jugador);
            try
            {
                if (apiResponseResult.Success)
                {
                    await jugadoresRepository.AgregarJugador(jugador);
                }
                return apiResponseResult;
            }
            catch (Exception ex)
            {
                apiResponseResult.Success = false;
                apiResponseResult.Message = ex.Message;
                return apiResponseResult;
            }
        }

        public async Task<ApiResponse<Jugador>> AgregarJugador(Jugador jugador)
        {
            
            ApiResponse<Jugador> apiResponseResult =
                jugadoresDomainService.AgregarJugador(jugador);
            try
            {
                if (apiResponseResult.Success)
                {
                    await jugadoresRepository.AgregarJugador(jugador);
                }
                return apiResponseResult;
            }
            catch (Exception ex) 
            { 
                apiResponseResult.Success = false;
                apiResponseResult.Message = ex.Message;
                return apiResponseResult;
            }
          
        }

        public async Task InactivarJugador(int id)
        {
            await jugadoresRepository.EliminarJugador(id);
        }

        public async Task<List<Jugador>> ObtenerJugadores()
        {
            List<Posicion> posiciones = await posicionesRepository.ObtenerPosiciones();
            List<Jugador> jugadores = await jugadoresRepository.ObtenerJugadores();

            var jugadoresConPosicion =
                (from p in jugadores
                 join c in posiciones on p.PosicionId equals c.Id
                 select new
                 {
                     p.Equipo,
                     p.NumeroCamisa,
                     c.Nombre

                 }).ToList();
            return await jugadoresRepository.ObtenerJugadores();
        }

        public async Task<Jugador> ObtenerJugadorPorId(int id)
        {
            return await jugadoresRepository.ObtenerJugadorPorId(id);
        }
    }
}
