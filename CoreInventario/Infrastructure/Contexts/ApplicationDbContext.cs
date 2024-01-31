using CoreInventario.Domain.Entities;
using CoreInventario.Infrastructure.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace CoreInventario.Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        // DbSets
        public DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }        
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.CliCodigo).IsUnique();
            });

            builder.Entity<Proveedor>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.PrvCodigo).IsUnique();
            });

            builder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.PrdCodigo).IsUnique();
                entity.HasOne(e => e.CategoriaProducto)
                    .WithMany(c => c.Producto)
                    .HasForeignKey("CatId")
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Proveedor)
                    .WithMany(c => c.Producto)
                    .HasForeignKey("PrvId")
                    .OnDelete(DeleteBehavior.NoAction);

            });

            builder.Entity<Entrada>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();                
                //entity.HasOne(e => e.Producto)
                //    .WithMany(c => c.)
                //    .HasForeignKey("EntId")
                //    .OnDelete(DeleteBehavior.NoAction);

            });

            // Atributos de campo
            builder.Entity<Producto>()
                .Property(p => p.PrdPrecioUnidad)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Entrada>()
                .Property(p => p.EntPrecioUnidad)
                .HasColumnType("decimal(18,2)");



        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
            optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLazyLoadingProxies();
        }


    }
}