namespace ApiJugadoresDb.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Equipo { get; set; }
        public int NumeroCamisa { get; set; }
        public int PosicionId { get; set; }
        public bool Activo { get; set; }
    }
}
