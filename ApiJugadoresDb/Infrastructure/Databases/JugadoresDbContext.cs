using ApiJugadoresDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiJugadoresDb.Infrastructure.Databases
{
    public class JugadoresDbContext : DbContext
    {
        public JugadoresDbContext(DbContextOptions options) : base(options)
        {
        }
        // Tablas
        public DbSet<Jugador> Jugadores => Set<Jugador>();
        public DbSet<Posicion> Posiciones => Set<Posicion>();

        // Mapeos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo para tabla jugador

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.ToTable("Jugadores");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("VARCHAR(100)");

                entity.Property(x => x.Equipo)
                .HasColumnName("Equipo")
                .HasColumnType("VARCHAR(100)");

                entity.Property(x => x.NumeroCamisa)
                .HasColumnName("NumeroCamisa")
                .HasColumnType("INT");

                entity.Property(x => x.PosicionId)
                .HasColumnName("PosicionId")
                .HasColumnType("INT");


                entity.Property(x => x.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT");
            });

            // Mapeo de tabla de posiciones
            modelBuilder.Entity<Posicion>(entity =>
            {
                entity.ToTable("Posiciones");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("VARCHAR(100)");

                entity.Property(x => x.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT");
            });
        }
    }
}