using Magic_Villa_7.Datos;
using Magic_Villa_7.Modelos;
using Magic_Villa_7.Repositorio.IRepositorio;

namespace Magic_Villa_7.Repositorio
{
    public class VillaRepositorio : Repositorio<Villa>, IVillaRepositorio
    {
        private readonly ApplicationDBContext _db;

        public VillaRepositorio(ApplicationDBContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<Villa> Actualizar(Villa entidad)
        {
            entidad.FechaActualizacion =DateTime.Now;
            _db.Villas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
            
        }
    }
}
