using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HumidityAndPMDataConnect.Models;

public partial class WeatherContext : DbContext
{
    public WeatherContext()
    {
    }

    public WeatherContext(DbContextOptions<WeatherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CountryInfo> CountryInfos { get; set; }

    public virtual DbSet<Pm25value> Pm25values { get; set; }

    public virtual DbSet<WeatherValue> WeatherValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ISLAB-210\\ISLAB_210;Database=Weather;User ID=sa;Password=123456789;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryInfo>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.ToTable("CountryInfo");

            entity.Property(e => e.CountryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CountryID");
            entity.Property(e => e.CountryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Pm25value>(entity =>
        {
            entity.HasKey(e => e.Pmindex);

            entity.ToTable("PM25Values");

            entity.Property(e => e.Pmindex).HasColumnName("PMIndex");
            entity.Property(e => e.CountryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CountryID");
            entity.Property(e => e.Pm25).HasColumnName("PM25");
            entity.Property(e => e.RecordTime).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.Pm25values)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_PM25Values_CountryInfo");
        });

        modelBuilder.Entity<WeatherValue>(entity =>
        {
            entity.HasKey(e => e.WeatherIndex);

            entity.Property(e => e.CountryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("countryID");
            entity.Property(e => e.RecordTime).HasColumnType("datetime");
            entity.Property(e => e.ValueName).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.WeatherValues)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_WeatherValues_CountryInfo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
