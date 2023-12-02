using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDev.Models
{
    public partial class FacturadorDBContext : DbContext
    {
        public FacturadorDBContext()
        {
        }

        public FacturadorDBContext(DbContextOptions<FacturadorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<FacturaCabecera> FacturaCabeceras { get; set; } = null!;
        public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; } = null!;
        public virtual DbSet<FacturasClienteHist> FacturasClienteHists { get; set; } = null!;
        public virtual DbSet<VistaFactura> VistaFacturas { get; set; } = null!;
        public virtual DbSet<VistaFacturasCliente> VistaFacturasClientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.ArtId);

                entity.ToTable("Articulo");

                entity.Property(e => e.ArtId).HasColumnName("ART_ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CliId);

                entity.ToTable("Cliente");

                entity.Property(e => e.CliId).HasColumnName("Cli_ID");

                entity.Property(e => e.Cuit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CUIT");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Razon_Social");
            });

            modelBuilder.Entity<FacturaCabecera>(entity =>
            {
                entity.HasKey(e => e.FcId)
                    .HasName("PK__Factura___20E5419282FE033A");

                entity.ToTable("Factura_Cabecera");

                entity.Property(e => e.FcId).HasColumnName("FC_ID");

                entity.Property(e => e.CliId).HasColumnName("Cli_ID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.FacturaCabeceras)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Cabecera_Cliente");
            });

            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.FcDtlId);

                entity.ToTable("Factura_Detalle");

                entity.Property(e => e.FcDtlId).HasColumnName("FC_DTL_ID");

                entity.Property(e => e.ArtId).HasColumnName("ART_ID");

                entity.Property(e => e.Cant).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FactId).HasColumnName("Fact_ID");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Art)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.ArtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Detalle_Articulo");

                entity.HasOne(d => d.Fact)
                    .WithMany(p => p.FacturaDetalles)
                    .HasForeignKey(d => d.FactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Detalle_Factura_Cabecera");
            });

            modelBuilder.Entity<FacturasClienteHist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Facturas_ClienteHIST");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.FcCabeceraId).HasColumnName("FcCabecera_ID");

                entity.Property(e => e.FecCreaReg)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<VistaFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VistaFacturas");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FcId).HasColumnName("FC_ID");

                entity.Property(e => e.Total).HasColumnType("decimal(38, 0)");
            });

            modelBuilder.Entity<VistaFacturasCliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VistaFacturasClientes");

                entity.Property(e => e.Cuit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CUIT");

                entity.Property(e => e.FcId).HasColumnName("FC_ID");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Razon_Social");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
