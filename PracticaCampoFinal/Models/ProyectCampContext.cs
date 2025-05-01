using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PracticaCampoFinal.Models;

public partial class ProyectCampContext : DbContext
{
    public ProyectCampContext()
    {
    }

    public ProyectCampContext(DbContextOptions<ProyectCampContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Pedidosdetalle> Pedidosdetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=ProyectCamp;user=root;password=Admin582001$", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.ApeCliente)
                .HasMaxLength(50)
                .HasColumnName("Ape_Cliente");
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(50)
                .HasColumnName("Email_Cliente");
            entity.Property(e => e.NameCliente)
                .HasMaxLength(40)
                .HasColumnName("Name_Cliente");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(15)
                .HasColumnName("Telefono_Cliente");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.IdCliente, "Id_Cliente");

            entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(20)
                .HasColumnName("Estado_Pedido");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pedido");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_ibfk_1");
        });

        modelBuilder.Entity<Pedidosdetalle>(entity =>
        {
            entity.HasKey(e => e.IdPedidoDetalle).HasName("PRIMARY");

            entity.ToTable("pedidosdetalles");

            entity.HasIndex(e => e.IdPedido, "Id_Pedido");

            entity.HasIndex(e => e.IdProducto, "Id_Producto");

            entity.Property(e => e.IdPedidoDetalle).HasColumnName("Id_PedidoDetalle");
            entity.Property(e => e.CantidadPedidoDetalle).HasColumnName("cantidad_PedidoDetalle");
            entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.PrecioUnitPedido)
                .HasPrecision(10, 2)
                .HasColumnName("PrecioUnit_Pedido");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Pedidosdetalles)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidosdetalles_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Pedidosdetalles)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidosdetalles_ibfk_2");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.CantidadProducto).HasColumnName("Cantidad_Producto");
            entity.Property(e => e.DescripcionProducto).HasColumnName("Descripcion_Producto");
            entity.Property(e => e.NameProducto)
                .HasMaxLength(50)
                .HasColumnName("Name_Producto");
            entity.Property(e => e.PrecioProducto)
                .HasPrecision(10, 2)
                .HasColumnName("Precio_Producto");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ContraUsuario)
                .HasMaxLength(12)
                .HasColumnName("Contra_Usuario");
            entity.Property(e => e.NameUsuario)
                .HasMaxLength(50)
                .HasColumnName("Name_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
