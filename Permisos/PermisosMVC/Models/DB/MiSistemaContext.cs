using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PermisosMVC.Models.DB;

public partial class MiSistemaContext : DbContext
{
    public MiSistemaContext()
    {
    }

    public MiSistemaContext(DbContextOptions<MiSistemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Operacione> Operaciones { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolOperacion> RolOperacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=MiSistema; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.ToTable("modulo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Operacione>(entity =>
        {
            entity.ToTable("operaciones");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Operaciones)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK_operaciones_modulo");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("rol");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolOperacion>(entity =>
        {
            entity.ToTable("rol_operacion");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.RolOperacions)
                .HasForeignKey(d => d.IdOperacion)
                .HasConstraintName("FK_rol_operacion_operaciones");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolOperacions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_rol_operacion_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_usuario_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
