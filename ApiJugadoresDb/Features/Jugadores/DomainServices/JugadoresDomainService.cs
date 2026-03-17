using ApiJugadoresDb.Commons.Models;
using ApiJugadoresDb.Entities;

namespace ApiJugadoresDb.Features.Jugadores.DomainServices
{
    public class JugadoresDomainService
    {
        public JugadoresDomainService()
        {
            
        }

        public ApiResponse<Jugador> AgregarJugador(Jugador jugador)
        {
            ApiResponse<Jugador> apiResponse = new ApiResponse<Jugador>();
            apiResponse.Success = true;
            if (string.IsNullOrEmpty(jugador.Nombre))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El nombre del jugador no puede ir vacio";
            }
            if (jugador.NumeroCamisa < 0)
            {
                apiResponse.Success = false;
                apiResponse.Message = "El numero de camisa no puede ser negativo";
            }
            apiResponse.Data = jugador; 
            return apiResponse;
 
        }
    }
}
