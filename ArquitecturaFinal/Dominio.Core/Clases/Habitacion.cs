using System.ComponentModel.DataAnnotations;

namespace Dominio.Core
{
    public class Habitacion
    {
        public int HabitacionID { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required, StringLength(300)]
        public string Descripcion { get; set; }

        [Required]
        public int NumeroHabitacion { get; set; }
    }
}
