using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Nombre es Requerido")]
        [MaxLength(20)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(20)]
        public string Apellidos { get; set; }
        [Required]
        [MaxLength(50)]
        public string Direccion { get; set; }
        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
