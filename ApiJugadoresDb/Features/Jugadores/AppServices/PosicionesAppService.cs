using ApiJugadoresDb.Commons.Models;
using ApiJugadoresDb.Entities;
using ApiJugadoresDb.Features.Jugadores.DomainServices;
using ApiJugadoresDb.Features.Jugadores.Interfaces;
using ApiJugadoresDb.Infrastructure.Interfaces;
using ApiJugadoresDb.Infrastructure.Repository;

namespace ApiJugadoresDb.Features.Jugadores.AppServices
{
    public class PosicionesAppService : IPosicionesAppService
    {
        public readonly IPosicionesRepository posicionesRepository;
        public readonly PosicionesDomainService posicionesDomainService;
        public PosicionesAppService(IPosicionesRepository posicionesRepository, PosicionesDomainService posicionesDomainService)
        {
            this.posicionesRepository = posicionesRepository;
            this.posicionesDomainService = posicionesDomainService;
        }
        public async Task<ApiResponse<Posicion>> AgregarPosicion(Posicion posicion)
        {
            ApiResponse<Posicion> apiResponseResult =
                posicionesDomainService.AgregarPosicion(posicion);
            try
            {
                if (apiResponseResult.Success)
                {
                    await posicionesRepository.AgregarPosicion(posicion);
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

        public async Task<List<Posicion>> ObtenerPosiciones()
        {
            return await posicionesRepository.ObtenerPosiciones();
        }
    }
}
