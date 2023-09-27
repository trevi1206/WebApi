﻿using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_7.Modelos.VillaDTO
{
    public class VillaCreateDTO
    {
        public int ID { get; set; }


        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        [Required]
        public double Tarifa { get; set; }
        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
