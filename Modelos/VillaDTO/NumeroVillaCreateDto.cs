using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_7.Modelos.VillaDTO
{
    public class NumeroVillaCreateDto
    {
        [Required]
        public int Villa_No { get; set; }

        [Required]
        public int Villa_Id { get; set; }
        public string Detalle_Especial { get; set; }
    }
}
