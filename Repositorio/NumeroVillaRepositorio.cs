using Magic_Villa_7.Datos;
using Magic_Villa_7.Modelos;
using Magic_Villa_7.Repositorio.IRepositorio;

namespace Magic_Villa_7.Repositorio
{
    public class NumeroVillaRepositorio : Repositorio<NumeroVilla>, INumeroVillaRepositorio
    {
        private readonly ApplicationDBContext _db;

        public NumeroVillaRepositorio(ApplicationDBContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<NumeroVilla> Actualizar(NumeroVilla entidad)
        {
            entidad.FechaActualizacion =DateTime.Now;
            _db.NumeroVillas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
            
        }
    }
}
