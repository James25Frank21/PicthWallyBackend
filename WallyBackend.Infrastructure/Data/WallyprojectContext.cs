using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WallyBackend.Infrastructure.Data;

public partial class WallyprojectContext : DbContext
{
    public WallyprojectContext()
    {
    }

    public WallyprojectContext(DbContextOptions<WallyprojectContext> options)
        : base(options)

    {
    }

    public virtual DbSet<Historialchat> Historialchat { get; set; }

    public virtual DbSet<Materialesreciclados> Materialesreciclados { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=wallyproject;uid=root;pwd=sistemas", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Historialchat>(entity =>
        {
            entity.HasKey(e => e.ChatId).HasName("PRIMARY");

            entity.ToTable("historialchat");

            entity.HasIndex(e => e.UsuarioEnviadorId, "usuario_enviador_id");

            entity.HasIndex(e => e.UsuarioReceptorId, "usuario_receptor_id");

            entity.Property(e => e.ChatId).HasColumnName("chat_id");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.IsActive).HasColumnType("bit(1)");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");
            entity.Property(e => e.UsuarioEnviadorId).HasColumnName("usuario_enviador_id");
            entity.Property(e => e.UsuarioReceptorId).HasColumnName("usuario_receptor_id");

            entity.HasOne(d => d.UsuarioEnviador).WithMany(p => p.HistorialchatUsuarioEnviador)
                .HasForeignKey(d => d.UsuarioEnviadorId)
                .HasConstraintName("historialchat_ibfk_1");

            entity.HasOne(d => d.UsuarioReceptor).WithMany(p => p.HistorialchatUsuarioReceptor)
                .HasForeignKey(d => d.UsuarioReceptorId)
                .HasConstraintName("historialchat_ibfk_2");
        });

        modelBuilder.Entity<Materialesreciclados>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PRIMARY");

            entity.ToTable("materialesreciclados");

            entity.HasIndex(e => e.Estado, "estado");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasColumnType("enum('disponible','vendido')")
                .HasColumnName("estado");
            entity.Property(e => e.FotoMaterial)
                .HasMaxLength(255)
                .HasColumnName("foto_material");
            entity.Property(e => e.IsActive).HasColumnType("bit(1)");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 8)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(11, 8)
                .HasColumnName("longitud");
            entity.Property(e => e.NombreMaterial)
                .HasMaxLength(100)
                .HasColumnName("nombre_material");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Materialesreciclados)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("materialesreciclados_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => new { e.Latitud, e.Longitud }, "latitud");

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(255)
                .HasColumnName("foto_perfil");
            entity.Property(e => e.IsActive).HasColumnType("bit(1)");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 8)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(11, 8)
                .HasColumnName("longitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Reputacion)
                .HasPrecision(3, 2)
                .HasColumnName("reputacion");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .HasColumnName("sexo");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
