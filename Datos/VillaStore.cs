using Magic_Villa_7.Modelos.VillaDTO;

namespace Magic_Villa_7.Datos
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>()

        {
            new VillaDTO{ID=1, Nombre="Tu puedes Kakaroto eres el numero 1", Ocupantes=3, MetrosCuadrados=50},
            new VillaDTO{ID=2, Nombre="Quieres saber el error que comestiste?", Ocupantes=4, MetrosCuadrados=80}
        };

    }
}
