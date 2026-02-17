using Contact_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.DataAccess;

public class ManagerDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base(options) {    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(emp =>
        {
            emp.HasKey(e => e.Id);
            
            emp.Property(e=> e.BirthDate)
                .IsRequired()
                .HasColumnType("date");
            
            emp.Property(e=> e.Married)
                .IsRequired();
            
            emp.Property(e=> e.Name)
                .IsRequired()
                .HasMaxLength(100);

            emp.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20);
            
            emp.Property(e=> e.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        });
    }
}