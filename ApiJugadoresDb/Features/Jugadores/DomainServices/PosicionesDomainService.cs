using ApiJugadoresDb.Commons.Models;
using ApiJugadoresDb.Entities;

namespace ApiJugadoresDb.Features.Jugadores.DomainServices
{
    public class PosicionesDomainService
    {
        public PosicionesDomainService()
        {
            
        }
        public ApiResponse<Posicion> AgregarPosicion(Posicion posicion)
        {
            ApiResponse<Posicion> apiResponse = new ApiResponse<Posicion>();
            apiResponse.Success = true;
            if (string.IsNullOrEmpty(posicion.Nombre))
            {
                apiResponse.Success = false;
                apiResponse.Message = "La posicion no puede ir vacia";
            }
            apiResponse.Data = posicion;
            return apiResponse;

        }
    }
}
