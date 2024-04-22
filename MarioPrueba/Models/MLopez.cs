using System.ComponentModel.DataAnnotations;

namespace MarioPrueba.Models
{
    public class MLopez
    {
        public  required int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }
        public int Edad {get; set; }
        [Required(ErrorMessage = "Se debe especificar si el estuidante esta activo")]
        public bool activo { get; set; }
        public float PromedioCalificaciones { get; set; }
        public DateTime FechaNacimiento { get; set; }
        
        public Carrera carrera { get; set; }    
    }
}
