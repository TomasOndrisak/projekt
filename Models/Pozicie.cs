using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Pozicie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nazov { get; set; }
      
        
    }
}
