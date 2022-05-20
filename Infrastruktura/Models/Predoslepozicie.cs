using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastruktura.Models
{
    public class Predoslepozicie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DatumUkoncenia { get; set; }
        [Required]
        public DateTime DatumNastupu { get; set; }

        [Required]
        public int idZamestnanca { get; set; }
        [ForeignKey("idZamestnanca")]
        public Zamestnanci Zamestnanci { get; set; }
        [Required]
        public string idPozicie { get; set; }
        
        

       


    }
}
