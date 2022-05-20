using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastruktura.Models
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
        public DateTime DatumNarodenia { get; set; }
        [Required]
        public DateTime DatumNastupu { get; set; }
        [Required]
        public int idPozicie { get; set; }
    
        [ForeignKey("idPozicie")]
        public Pozicie Pozicie { get; set; }
        [Required]
        public float Plat { get; set; }
        [Required]
        public bool Archivovany { get; set; }
        public ICollection<Zamestnanci> ZamestnanciList { get; set; }
        public Pozicie pozicie { get; set; }
        




    }
}
