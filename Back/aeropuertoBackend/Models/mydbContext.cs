using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aeropuertoBackend.Models
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudade> Ciudades { get; set; } = null!;
        public virtual DbSet<Estacionamiento> Estacionamientos { get; set; } = null!;
        public virtual DbSet<Reporteincidencia> Reporteincidencias { get; set; } = null!;
        public virtual DbSet<Reservasestacionamiento> Reservasestacionamientos { get; set; } = null!;
        public virtual DbSet<Reservasvuelo> Reservasvuelos { get; set; } = null!;
        public virtual DbSet<Tiposavion> Tiposavions { get; set; } = null!;
        public virtual DbSet<Tiposusuario> Tiposusuarios { get; set; } = null!;
        public virtual DbSet<Turno> Turnos { get; set; } = null!;
        public virtual DbSet<Turnosempleado> Turnosempleados { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vuelo> Vuelos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=localhost;Port=3306;Uid=root;Pwd=root;Database=mydb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudade>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("PRIMARY");

                entity.ToTable("ciudades");

                entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");

                entity.Property(e => e.NombreCiudad)
                    .HasMaxLength(45)
                    .HasColumnName("nombreCiudad");
            });

            modelBuilder.Entity<Estacionamiento>(entity =>
            {
                entity.HasKey(e => e.IdEstacionamiento)
                    .HasName("PRIMARY");

                entity.ToTable("estacionamiento");

                entity.Property(e => e.IdEstacionamiento).HasColumnName("idEstacionamiento");

                entity.Property(e => e.DisponibilidadTotal).HasColumnName("disponibilidadTotal");

                entity.Property(e => e.NombreEstacionamiento)
                    .HasMaxLength(45)
                    .HasColumnName("nombreEstacionamiento");
            });

            modelBuilder.Entity<Reporteincidencia>(entity =>
            {
                entity.HasKey(e => e.IdreporteIncidencias)
                    .HasName("PRIMARY");

                entity.ToTable("reporteincidencias");

                entity.HasIndex(e => e.IdUsuarioReporto, "idUsuarioReport_idx");

                entity.Property(e => e.IdreporteIncidencias).HasColumnName("idreporteIncidencias");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(1000)
                    .HasColumnName("comentario");

                entity.Property(e => e.IdUsuarioReporto).HasColumnName("idUsuarioReporto");

                entity.HasOne(d => d.IdUsuarioReportoNavigation)
                    .WithMany(p => p.Reporteincidencia)
                    .HasForeignKey(d => d.IdUsuarioReporto)
                    .HasConstraintName("idUsuarioReport");
            });

            modelBuilder.Entity<Reservasestacionamiento>(entity =>
            {
                entity.HasKey(e => e.IdReservasEstacionamiento)
                    .HasName("PRIMARY");

                entity.ToTable("reservasestacionamiento");

                entity.HasIndex(e => e.IdEstacionamiento, "idEstacionamiento_idx");

                entity.HasIndex(e => e.IdUsuario, "idUsuario_idx");

                entity.Property(e => e.IdReservasEstacionamiento).HasColumnName("idReservasEstacionamiento");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.HoraEntrada)
                    .HasColumnType("time")
                    .HasColumnName("horaEntrada");

                entity.Property(e => e.HoraSalida)
                    .HasColumnType("time")
                    .HasColumnName("horaSalida");

                entity.Property(e => e.IdEstacionamiento).HasColumnName("idEstacionamiento");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEstacionamientoNavigation)
                    .WithMany(p => p.Reservasestacionamientos)
                    .HasForeignKey(d => d.IdEstacionamiento)
                    .HasConstraintName("idEstacionamiento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservasestacionamientos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("idUsuario");
            });

            modelBuilder.Entity<Reservasvuelo>(entity =>
            {
                entity.HasKey(e => e.IdReservasVuelo)
                    .HasName("PRIMARY");

                entity.ToTable("reservasvuelo");

                entity.HasIndex(e => e.IdUsuario, "idUsuarioRes_idx");

                entity.HasIndex(e => e.IdVuelo, "idVuelo_idx");

                entity.Property(e => e.IdReservasVuelo).HasColumnName("idReservasVuelo");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");

                entity.Property(e => e.TipoAsiento).HasColumnName("tipoAsiento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservasvuelos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("idUsuarioRes");

                entity.HasOne(d => d.IdVueloNavigation)
                    .WithMany(p => p.Reservasvuelos)
                    .HasForeignKey(d => d.IdVuelo)
                    .HasConstraintName("idVuelo");
            });

            modelBuilder.Entity<Tiposavion>(entity =>
            {
                entity.HasKey(e => e.IdTiposAvion)
                    .HasName("PRIMARY");

                entity.ToTable("tiposavion");

                entity.Property(e => e.IdTiposAvion).HasColumnName("idTiposAvion");
            });

            modelBuilder.Entity<Tiposusuario>(entity =>
            {
                entity.HasKey(e => e.IdtipoUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tiposusuario");

                entity.Property(e => e.IdtipoUsuario).HasColumnName("idtipoUsuario");

                entity.Property(e => e.TipoUsuario)
                    .HasMaxLength(45)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.Idturno)
                    .HasName("PRIMARY");

                entity.ToTable("turnos");

                entity.Property(e => e.Idturno).HasColumnName("idturno");

                entity.Property(e => e.HoraEntrada)
                    .HasColumnType("time")
                    .HasColumnName("horaEntrada");

                entity.Property(e => e.HoraSalida)
                    .HasColumnType("time")
                    .HasColumnName("horaSalida");

                entity.Property(e => e.NombreTurno)
                    .HasMaxLength(45)
                    .HasColumnName("nombreTurno");
            });

            modelBuilder.Entity<Turnosempleado>(entity =>
            {
                entity.HasKey(e => e.IdTurnosEmpleados)
                    .HasName("PRIMARY");

                entity.ToTable("turnosempleados");

                entity.HasIndex(e => e.IdTurno, "idTurno_idx");

                entity.HasIndex(e => e.IdUsuario, "idUsuarioTurno_idx");

                entity.Property(e => e.IdTurnosEmpleados).HasColumnName("idTurnosEmpleados");

                entity.Property(e => e.IdTurno).HasColumnName("idTurno");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.TurnosEmpleadoscol).HasMaxLength(45);

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.Turnosempleados)
                    .HasForeignKey(d => d.IdTurno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("idTurno");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Turnosempleados)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idUsuarioTurno");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdTipoUsuario, "tipoUsuario_idx");

                entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .HasColumnName("correo");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tipoUsuario");
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IdVuelos)
                    .HasName("PRIMARY");

                entity.ToTable("vuelos");

                entity.HasIndex(e => e.Destino, "destino_idx");

                entity.HasIndex(e => e.Origen, "origen_idx");

                entity.HasIndex(e => e.IdTipoAvion, "tipoAvion_idx");

                entity.Property(e => e.IdVuelos).HasColumnName("idVuelos");

                entity.Property(e => e.FechaSalida).HasColumnType("date");

                entity.Property(e => e.HoraLlegada).HasColumnType("time");

                entity.Property(e => e.HoraSalida).HasColumnType("time");

                entity.Property(e => e.IdTipoAvion).HasColumnName("idTipoAvion");

                entity.HasOne(d => d.DestinoNavigation)
                    .WithMany(p => p.VueloDestinoNavigations)
                    .HasForeignKey(d => d.Destino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("destino");

                entity.HasOne(d => d.IdTipoAvionNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IdTipoAvion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tipoAvion");

                entity.HasOne(d => d.OrigenNavigation)
                    .WithMany(p => p.VueloOrigenNavigations)
                    .HasForeignKey(d => d.Origen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("origen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
