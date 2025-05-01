using Microsoft.EntityFrameworkCore;
using PracticaCampoFinal.Models;

namespace PracticaCampoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Cliente> Usuarios { get; set; } // Representacion de la tabla Usuarios
        public DbSet<Cliente> Clientes { get; set; } // Representacion de la tabla Clientes
        public DbSet<Cliente> Productos { get; set; } // Representacion de la tabla Productos
        public DbSet<Cliente> Pedidos { get; set; } // Representacion de la tabla Pedidos
        public DbSet<Cliente> PedidosDetalles { get; set; } // Representacion de la tabla PedidosDetalles


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Pedido y Cliente
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.Id_Cliente)
                .OnDelete(DeleteBehavior.Cascade); // Configuración de eliminación en cascada

            // Configuración de la relación entre Pedidosdetalle y Pedido
            modelBuilder.Entity<Pedidosdetalle>()
                .HasOne(pd => pd.Pedido)
                .WithMany(p => p.Pedidosdetalles)
                .HasForeignKey(pd => pd.Id_Pedido)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la relación entre Pedidosdetalle y Producto
            modelBuilder.Entity<Pedidosdetalle>()
                .HasOne(pd => pd.Producto)
                .WithMany()
                .HasForeignKey(pd => pd.Id_Producto)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
