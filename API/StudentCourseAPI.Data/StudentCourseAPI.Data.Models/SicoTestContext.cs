﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseAPI.Data.StudentCourseAPI.Data.Models;

public partial class SicoTestContext : DbContext
{
    public SicoTestContext()
    {
    }

    public SicoTestContext(DbContextOptions<SicoTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EstudianteXCurso> EstudianteXCursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Sico_Test;User Id=sa;Password=123456;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso);

            entity.ToTable("CURSO");

            entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");
            entity.Property(e => e.Dificultad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIFICULTAD");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CURSO");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante);

            entity.ToTable("ESTUDIANTE");

            entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");
            entity.Property(e => e.ApellidosEstudiante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS_ESTUDIANTE");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.NombresEstudiante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRES_ESTUDIANTE");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<EstudianteXCurso>(entity =>
        {
            entity.HasKey(e => e.IdEstudianteXCurso);

            entity.ToTable("ESTUDIANTE_X_CURSO");

            entity.Property(e => e.IdEstudianteXCurso).HasColumnName("ID_ESTUDIANTE_X_CURSO");
            entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");
            entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.EstudianteXCursos)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK_ESTUDIANTE_X_CURSO_CURSO");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.EstudianteXCursos)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK_ESTUDIANTE_X_CURSO_ESTUDIANTE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
