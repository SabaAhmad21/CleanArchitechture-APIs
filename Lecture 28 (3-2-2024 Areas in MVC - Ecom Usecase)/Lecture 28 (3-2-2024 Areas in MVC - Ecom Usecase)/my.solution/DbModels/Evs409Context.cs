using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbModels;

public partial class Evs409Context : DbContext
{
    public Evs409Context()
    {
    }

    public Evs409Context(DbContextOptions<Evs409Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Jsontable> Jsontables { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentRecord> StudentRecords { get; set; }

    public virtual DbSet<WebsiteSetting> WebsiteSettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ED0AGU8;Database=EVS-409;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true; Integrated security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories", "inventory");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Departments", "setup");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.ToTable("employes");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsGraduated).HasColumnName("isGraduated");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Genders", "setup");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Jsontable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("JSONTable");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsGraduated).HasColumnName("isGraduated");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students", "student");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImgName).HasMaxLength(500);
            entity.Property(e => e.RollNumber).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(150);

            entity.HasOne(d => d.Departement).WithMany(p => p.Students)
                .HasForeignKey(d => d.DepartementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Departments");

            entity.HasOne(d => d.Gender).WithMany(p => p.Students)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Genders");
        });

        modelBuilder.Entity<StudentRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("StudentRecords");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.ImgUrl).HasMaxLength(1000);
            entity.Property(e => e.RollNumber).HasMaxLength(50);
            entity.Property(e => e.StdGender).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(150);
        });

        modelBuilder.Entity<WebsiteSetting>(entity =>
        {
            entity.ToTable("WebsiteSettings", "setting");

            entity.Property(e => e.SettingName).HasMaxLength(50);
            entity.Property(e => e.Value).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
