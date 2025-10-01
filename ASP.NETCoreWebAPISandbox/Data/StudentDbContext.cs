using ASP.NETCoreWebAPISandbox.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebAPISandbox.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity => {
                entity.ToTable("tbl_student");

                entity.HasKey(student => student.Id);

                entity.Property(student => student.Id)
                    .HasColumnName("id")
                    .HasColumnType("INT")
                    .UseIdentityAlwaysColumn();

                entity.Property(student => student.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(100)");
            });
        }
    }
}
