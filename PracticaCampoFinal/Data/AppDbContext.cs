using Microsoft.EntityFrameworkCore;
using PracticaCampoFinal.Models;

namespace PracticaCampoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Usuario> Usuarios { get; set; } // Representacion de la tabla Usuarios
        public DbSet<Cliente> Clientes { get; set; } // Representacion de la tabla Clientes
        public DbSet<Producto> Productos { get; set; } // Representacion de la tabla Productos
        public DbSet<Pedido> Pedidos { get; set; } // Representacion de la tabla Pedidos
        public DbSet<Pedidosdetalle> PedidosDetalles { get; set; } // Representacion de la tabla PedidosDetalles

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones opcionales si los nombres de las tablas o columnas difieren
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.Id_Cliente);

            modelBuilder.Entity<Pedidosdetalle>()
                .HasOne(d => d.Pedido)
                .WithMany()
                .HasForeignKey(d => d.Id_Pedido);

            modelBuilder.Entity<Pedidosdetalle>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.Id_Producto);
        }
    }
}
