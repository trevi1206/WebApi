using Magic_Villa_7.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Magic_Villa_7.Datos
{
    public class ApplicationDBContext :DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    ID = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la villa...",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now,

                },
                new Villa()
                {
                    ID = 2,
                    Nombre = "Villa Los Campos",
                    Detalle = "Detalle de la villa...",
                    ImagenUrl = "",
                    Ocupantes = 6,
                    MetrosCuadrados = 20,
                    Tarifa = 500,
                    Amenidad = "",
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now,

                });

        }
    }
}
