using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final1.Usuarios;
using Proyecto_Final1.Carritos;
using Proyecto_Final1.Pedidos;
using Proyecto_Final1.Productos;
using Proyecto_Final1.Models.Usuarios; // Agregado

namespace Proyecto_Final1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }
        public DbSet<DetallePedidos> DetallePedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoVariacion> ProductoVariaciones { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }
        public DbSet<DireccionDeEnvio> DireccionesDeEnvio { get; set; }
        public DbSet<Consulta> Consultas { get; set; } // Agregado
        public DbSet<Preguntas> Preguntas { get; set; } // Agregado

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.DireccionDeEnvio)
                .WithMany()
                .HasForeignKey(p => p.DireccionDeEnvioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DireccionDeEnvio>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.DireccionesDeEnvio)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarritoItem>()
                .HasOne(ci => ci.Carrito)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CarritoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Carritos)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetallePedidos>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Valoracion>()
                .HasOne(v => v.Usuario)
                .WithMany(u => u.Valoraciones)
                .HasForeignKey(v => v.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relaciones para los nuevos modelos (opcional, pero recomendado)
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Preguntas>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarritoItem>()
                .Property(ci => ci.PrecioUnitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DetallePedidos>()
                .Property(dp => dp.PrecioUnitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProductoVariacion>()
                .Property(pv => pv.PrecioAdicional)
                .HasPrecision(18, 2);
        }
    }
}