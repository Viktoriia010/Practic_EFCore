using Academy.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Context;

public class AcademyDbContext:DbContext
{
    public DbSet<Student> Students { get; set; }

    //public DbSet<Teachers> Teacherss { get; set; }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Curators> Curators { get; set; }

    public DbSet<Grade> Grades { get; set; }


    public AcademyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Grade>()
            .Property(g => g.Value)
            .IsRequired();

        modelBuilder.Entity<Grade>()
            .ToTable(t => t.HasCheckConstraint("CK_Grade_Value_Range", "[Value] BETWEEN 1 AND 12"));

        modelBuilder.Entity<Subject>()
            .Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId);

        modelBuilder.Entity<Curators>()
            .HasOne(c => c.Groups)
            .WithOne(g => g.Curators)
            .HasForeignKey<Group>(g => g.CuratorId);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Subject)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.SubjectId);


    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //    optionsBuilder.UseSqlServer("Server=DESKTOP-BI99DMD\\SQLEXPRESS;Database=academyPV521;Trusted_Connection=True;TrustServerCertificate=True;");
    //}
}
