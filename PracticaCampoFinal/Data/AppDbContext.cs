using Microsoft.EntityFrameworkCore;
using PracticaCampoFinal.Models;

namespace PracticaCampoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Cliente> Clientes { get; set; } // Representacion de la tabla Cliente
    }
}
