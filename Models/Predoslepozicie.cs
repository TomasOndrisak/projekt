using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Predoslepozicie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int idZamestnanca { get; set; }
        [Required]
        public string Pozicia { get; set; }
        [Required]
        public DateTime DatumUkoncenia { get; set; }
        [Required]
        public DateTime DatumNastupu { get; set; }

       


    }
}
