using System.ComponentModel.DataAnnotations;

namespace PracticaCampoFinal.Models
{
    public class Login
    {
        [Required] //Anotacion para validar que el campo no sea nulo
        public string Name_Usuario { get; set; }

        [Required]  //Anotacion para validar que el campo no sea nulo
        [DataType(DataType.Password)] //Anotacion para validar que el campo sea de tipo contraseña
        public string Contra_Usuario { get; set; }
    }
}
