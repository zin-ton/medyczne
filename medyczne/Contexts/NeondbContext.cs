using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace medyczne.Models;

public partial class NeondbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public NeondbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public NeondbContext(DbContextOptions<NeondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(
            "Host=ep-twilight-glitter-a25wp7gn.eu-central-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=nqksZmcr04PX");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("doctors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Login)
                .HasMaxLength(15)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patients_pk");

            entity.ToTable("patients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(15)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visits_pk");

            entity.ToTable("visits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}