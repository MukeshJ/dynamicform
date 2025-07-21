using HRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Data;

public class HRMSDbContext : DbContext
{
    public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<Salary> Salaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Employee Configuration
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.EmployeeId).IsRequired().HasMaxLength(20);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(500);
            
            entity.HasIndex(e => e.EmployeeId).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();

            entity.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Department Configuration
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Description).HasMaxLength(500);

            entity.HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // Role Configuration
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
            entity.Property(r => r.Description).HasMaxLength(500);
            entity.Property(r => r.Permissions).HasColumnType("nvarchar(max)");
            
            entity.HasIndex(r => r.Name).IsUnique();
        });

        // Attendance Configuration
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Notes).HasMaxLength(500);

            entity.HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(a => new { a.EmployeeId, a.Date }).IsUnique();
        });

        // Leave Request Configuration
        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Reason).IsRequired().HasMaxLength(1000);
            entity.Property(l => l.ApprovalComments).HasMaxLength(1000);

            entity.HasOne(l => l.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(l => l.ApprovedBy)
                .WithMany()
                .HasForeignKey(l => l.ApprovedById)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // Salary Configuration
        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.BasicSalary).HasColumnType("decimal(18,2)");
            entity.Property(s => s.Allowances).HasColumnType("decimal(18,2)");
            entity.Property(s => s.Deductions).HasColumnType("decimal(18,2)");
            entity.Property(s => s.GrossSalary).HasColumnType("decimal(18,2)");
            entity.Property(s => s.NetSalary).HasColumnType("decimal(18,2)");
            entity.Property(s => s.Comments).HasMaxLength(1000);

            entity.HasOne(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Seed Data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Roles
        var adminRoleId = Guid.NewGuid();
        var hrRoleId = Guid.NewGuid();
        var employeeRoleId = Guid.NewGuid();

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = adminRoleId,
                Name = "Admin",
                Description = "System Administrator",
                Permissions = "[\"READ\", \"WRITE\", \"DELETE\", \"MANAGE_USERS\"]",
                CreatedAt = DateTime.UtcNow
            },
            new Role
            {
                Id = hrRoleId,
                Name = "HR",
                Description = "Human Resources",
                Permissions = "[\"READ\", \"WRITE\", \"MANAGE_EMPLOYEES\"]",
                CreatedAt = DateTime.UtcNow
            },
            new Role
            {
                Id = employeeRoleId,
                Name = "Employee",
                Description = "Regular Employee",
                Permissions = "[\"READ\"]",
                CreatedAt = DateTime.UtcNow
            }
        );

        // Seed Departments
        var itDeptId = Guid.NewGuid();
        var hrDeptId = Guid.NewGuid();

        modelBuilder.Entity<Department>().HasData(
            new Department
            {
                Id = itDeptId,
                Name = "Information Technology",
                Description = "IT Department",
                CreatedAt = DateTime.UtcNow
            },
            new Department
            {
                Id = hrDeptId,
                Name = "Human Resources",
                Description = "HR Department",
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}