using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Archivovany
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
        public DateTime DatumPrepustenia { get; set; }
        [Required]
        public string Pozicia { get; set; }
        [Required]
        public float Plat { get; set; }
    }
}
