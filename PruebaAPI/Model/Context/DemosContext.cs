using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaAPI.Model.Entities;

#nullable disable

namespace PruebaAPI.Model.Context
{
    public partial class DemosContext : DbContext
    {
        public DemosContext()
        {
        }

        public DemosContext(DbContextOptions<DemosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<AlumnosBaja> AlumnosBajas { get; set; }
        public virtual DbSet<CatCurso> CatCursos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<CursosAlumno> CursosAlumnos { get; set; }
        public virtual DbSet<CursosInstructore> CursosInstructores { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<EstatusAlumno> EstatusAlumnos { get; set; }
        public virtual DbSet<Instructore> Instructores { get; set; }
        public virtual DbSet<Saldo> Saldos { get; set; }
        public virtual DbSet<TablaIsr> TablaIsrs { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
        public virtual DbSet<VAlumno> VAlumnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("curp")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IdEstadoOrigen).HasColumnName("idEstadoOrigen");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.SueldoMensual)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("sueldoMensual");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("telefono")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdEstadoOrigenNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdEstadoOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Alumnos__idEstad__22751F6C");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Alumnos__idEstat__236943A5");
            });

            modelBuilder.Entity<AlumnosBaja>(entity =>
            {
                entity.ToTable("AlumnosBaja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaBaja");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");
            });

            modelBuilder.Entity<CatCurso>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdPreRequisitos).HasColumnName("idPreRequisitos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdPreRequisitosNavigation)
                    .WithMany(p => p.InverseIdPreRequisitosNavigation)
                    .HasForeignKey(d => d.IdPreRequisitos)
                    .HasConstraintName("FK__CatCursos__idPre__1CBC4616");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.Fechatermino)
                    .HasColumnType("date")
                    .HasColumnName("fechatermino");

                entity.Property(e => e.IdCatCurso).HasColumnName("idCatCurso");

                entity.HasOne(d => d.IdCatCursoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCatCurso)
                    .HasConstraintName("FK__Cursos__idCatCur__1F98B2C1");
            });

            modelBuilder.Entity<CursosAlumno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("fechaBaja");

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("date")
                    .HasColumnName("fechaInscripcion");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.CursosAlumnos)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CursosAlu__idAlu__29221CFB");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursosAlumnos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CursosAlu__idCur__282DF8C2");
            });

            modelBuilder.Entity<CursosInstructore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaContratacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaContratacion");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursosInstructores)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CursosIns__idCur__2BFE89A6");

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.CursosInstructores)
                    .HasForeignKey(d => d.IdInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CursosIns__idIns__2CF2ADDF");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Curp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("curp")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<EstatusAlumno>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instructore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.CuotaHora)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("cuotaHora");

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("curp")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("rfc")
                    .IsFixedLength(true);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("telefono")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Saldo>(entity =>
            {
                entity.ToTable("saldos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo1)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("saldo");
            });

            modelBuilder.Entity<TablaIsr>(entity =>
            {
                entity.ToTable("TablaISR");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuotaFija).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.ExedLimInf).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.LimInf).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.LimSup).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Subsidio).HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDestino).HasColumnName("idDestino");

                entity.Property(e => e.IdOrigen).HasColumnName("idOrigen");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.TransaccioneIdDestinoNavigations)
                    .HasForeignKey(d => d.IdDestino)
                    .HasConstraintName("FK__Transacci__idDes__6DCC4D03");

                entity.HasOne(d => d.IdOrigenNavigation)
                    .WithMany(p => p.TransaccioneIdOrigenNavigations)
                    .HasForeignKey(d => d.IdOrigen)
                    .HasConstraintName("FK__Transacci__idOri__6CD828CA");
            });

            modelBuilder.Entity<VAlumno>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAlumnos");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("curp")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("telefono")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
