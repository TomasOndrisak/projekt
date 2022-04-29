using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Zamestnanci
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Meno { get; set; }
        [Required]
        public string Priezvisko { get; set; }
        public string Adresa { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumNarodenia { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumNastupu { get; set; }
        [Required]
        public string Pozicia { get; set; }
        [Required]
        public float Plat { get; set; }
        




    }
}
