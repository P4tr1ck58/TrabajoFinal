using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PracticaCampoFinal.Models
{
    public class Cliente
    {
        
        public string Name_Cliente { get; set; } //Nombre del cliente
        public string Ape_Cliente { get; set; } //Apellido del cliente
        public int Telefono_Cliente { get; set; } //Telefono del cliente
        public string Email_Cliente { get; set; } //Email del cliente
    
    }
}
