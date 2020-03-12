using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.WaterSolutionDBC
{
    public partial class WaterSolutionDBContext : DbContext
    {
        public WaterSolutionDBContext()
        {
        }

        public WaterSolutionDBContext(DbContextOptions<WaterSolutionDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cotizaciones> Cotizaciones { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<DetalleCotizacion> DetalleCotizacion { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<PermisoRole> PermisoRole { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolesPermisos> RolesPermisos { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<RutaEmpleado> RutaEmpleado { get; set; }
        public virtual DbSet<RutaSolicitud> RutaSolicitud { get; set; }
        public virtual DbSet<Secciones> Secciones { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=WINDOWS-ICD9Q78; Initial Catalog=WaterSolutionDB; Integrated Security=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.HasIndex(e => e.RoleIdRole);

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.NombreCargo)
                    .IsRequired()
                    .HasColumnName("nombreCargo")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleIdRole).HasColumnName("roleIdRole");

                entity.HasOne(d => d.RoleIdRoleNavigation)
                    .WithMany(p => p.Cargo)
                    .HasForeignKey(d => d.RoleIdRole);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.PersonaId)
                    .HasName("PK__Cliente__7C34D3233F353106");

                entity.Property(e => e.PersonaId)
                    .HasColumnName("PersonaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cotizaciones>(entity =>
            {
                entity.HasKey(e => e.CotizacionId)
                    .HasName("PK__Cotizaci__30443A596324F302");

                entity.Property(e => e.CotizacionId)
                    .HasColumnName("CotizacionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");

                entity.HasOne(d => d.Solicitud)
                    .WithMany(p => p.Cotizaciones)
                    .HasForeignKey(d => d.SolicitudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cotizaciones_Solicitud");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.Property(e => e.NombreDepartamento)
                    .IsRequired()
                    .HasColumnName("nombreDepartamento");
            });

            modelBuilder.Entity<DetalleCotizacion>(entity =>
            {
                entity.Property(e => e.DetalleCotizacionId)
                    .HasColumnName("DetalleCotizacionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CotizacionId).HasColumnName("CotizacionID");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.Presio).HasColumnName("presio");

                entity.Property(e => e.TotalDetalle).HasColumnName("totalDetalle");

                entity.HasOne(d => d.Cotizacion)
                    .WithMany(p => p.DetalleCotizacion)
                    .HasForeignKey(d => d.CotizacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cotizaciones_Detalle");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.DetalleCotizacion)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialID_Detalle");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.HasIndex(e => e.CargoidCargo);

                entity.HasIndex(e => e.SeccionIdSeccion);

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.ApellidosEmpleado)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.CargoidCargo).HasColumnName("cargoidCargo");

                entity.Property(e => e.CedulaEmpleado)
                    .IsRequired()
                    .HasColumnName("cedulaEmpleado");

                entity.Property(e => e.FechaEmpleado).HasColumnName("fechaEmpleado");

                entity.Property(e => e.IdDireccionEmpleado).HasColumnName("idDireccionEmpleado");

                entity.Property(e => e.IdTelefornoEmpleado).HasColumnName("idTelefornoEmpleado");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasColumnName("nombreEmpleado")
                    .HasMaxLength(4);

                entity.Property(e => e.SeccionIdSeccion).HasColumnName("seccionIdSeccion");

                entity.HasOne(d => d.CargoidCargoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CargoidCargo);

                entity.HasOne(d => d.SeccionIdSeccionNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.SeccionIdSeccion);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.MaterialId)
                    .HasColumnName("MaterialID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermisoRole>(entity =>
            {
                entity.HasKey(e => e.IdPermiso);

                entity.Property(e => e.NombrePermiso)
                    .IsRequired()
                    .HasColumnName("nombrePermiso");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.Property(e => e.EstadoRole).HasColumnName("estadoRole");

                entity.Property(e => e.NombreRole)
                    .IsRequired()
                    .HasColumnName("nombreRole");
            });

            modelBuilder.Entity<RolesPermisos>(entity =>
            {
                entity.HasKey(e => new { e.IdRole, e.IdPermiso });

                entity.HasIndex(e => new { e.IdPermiso, e.IdRole })
                    .HasName("AK_RolesPermisos_IdPermiso_IdRole")
                    .IsUnique();

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.RolesPermisos)
                    .HasForeignKey(d => d.IdPermiso);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.RolesPermisos)
                    .HasForeignKey(d => d.IdRole);
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.Property(e => e.RutaId)
                    .HasColumnName("RutaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<RutaEmpleado>(entity =>
            {
                entity.Property(e => e.RutaEmpleadoId)
                    .HasColumnName("RutaEmpleadoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");

                entity.Property(e => e.RutaId).HasColumnName("RutaID");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.RutaEmpleado)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RutaEnpleado_Empleado");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.RutaEmpleado)
                    .HasForeignKey(d => d.RutaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RutaEnplead_Ruta");
            });

            modelBuilder.Entity<RutaSolicitud>(entity =>
            {
                entity.Property(e => e.RutaSolicitudId)
                    .HasColumnName("RutaSolicitudID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RutaId).HasColumnName("RutaID");

                entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.RutaSolicitud)
                    .HasForeignKey(d => d.RutaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RutaSolicitud_ruta");

                entity.HasOne(d => d.Solicitud)
                    .WithMany(p => p.RutaSolicitud)
                    .HasForeignKey(d => d.SolicitudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RutaSolicitud_Solicitud");
            });

            modelBuilder.Entity<Secciones>(entity =>
            {
                entity.HasKey(e => e.IdSeccion);

                entity.HasIndex(e => e.DepartamentoIdDepartamento);

                entity.Property(e => e.NombreSeccion)
                    .IsRequired()
                    .HasColumnName("nombreSeccion");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNavigation)
                    .WithMany(p => p.Secciones)
                    .HasForeignKey(d => d.DepartamentoIdDepartamento);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.Property(e => e.SolicitudId)
                    .HasColumnName("SolicitudID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSolicitud)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.PersonaId).HasColumnName("PersonaID");

                entity.Property(e => e.SeccionId).HasColumnName("SeccionID");

                entity.Property(e => e.Sector)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSolicitud)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Solicitud");

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.SeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seccion_Solicitud");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.EmpleadoUsuarioidEmpleado);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.EmpleadoUsuarioidEmpleado).HasColumnName("empleadoUsuarioidEmpleado");

                entity.Property(e => e.EstadoUsuario).HasColumnName("estadoUsuario");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(4);

                entity.Property(e => e.PasswordUsuario).HasColumnName("passwordUsuario");

                entity.HasOne(d => d.EmpleadoUsuarioidEmpleadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpleadoUsuarioidEmpleado);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
