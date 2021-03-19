using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VegamTask.Models
{
    public partial class StudentDetailsdbContext : DbContext
    {
        public StudentDetailsdbContext()
        {
        }

        public StudentDetailsdbContext(DbContextOptions<StudentDetailsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=StudentDetailsdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Student");

                entity.Property(e => e.Fmarks).HasColumnName("FMarks");

                entity.Property(e => e.FstudentId).HasColumnName("FStudentID");

                entity.Property(e => e.FstudentName)
                    .HasMaxLength(50)
                    .HasColumnName("FStudentName");

                entity.Property(e => e.Fsubject)
                    .HasMaxLength(20)
                    .HasColumnName("FSubject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
