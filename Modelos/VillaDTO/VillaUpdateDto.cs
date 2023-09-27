﻿using System.ComponentModel.DataAnnotations;

namespace Magic_Villa_7.Modelos.VillaDTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int ID { get; set; }


        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        [Required]
        public double Tarifa { get; set; }
        [Required]
        public int Ocupantes { get; set; }
        [Required]
        public int MetrosCuadrados { get; set; }
        [Required]
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}