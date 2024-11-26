using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ContosoUniversityApi.Data;

public class SchoolContext(DbContextOptions<SchoolContext> options) : DbContext(options)
{
    private IDbContextTransaction? _currentTransaction;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable(nameof(Course));
            x.Property(p => p.Title).HasMaxLength(50).IsRequired(true);
        });

        modelBuilder.Entity<Department>(x =>
        {
            x.ToTable(nameof(Department));
            x.Property(p => p.Name).HasMaxLength(50).IsRequired(true);
            x.Property(p => p.Budget).HasPrecision(9, 0);
            x.Property(x => x.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<Instructor>(x =>
        {
            x.ToTable(nameof(Instructor));
            x.Property(p => p.FirstName).HasMaxLength(50).IsRequired(true);
            x.Property(p => p.LastName).HasMaxLength(50).IsRequired(true);
        });

        modelBuilder.Entity<OfficeAssignment>(x =>
        {
            x.ToTable(nameof(OfficeAssignment));
            x.HasKey(p => p.InstructorId);
            x.Property(p => p.Location).HasMaxLength(50).IsRequired(true);
        });

        modelBuilder.Entity<CourseAssignment>(x =>
        {
            x.ToTable(nameof(CourseAssignment));
            x.HasKey(nameof(CourseAssignment.CourseId), nameof(CourseAssignment.InstructorId));
        });

        modelBuilder.Entity<Student>(x =>
        {
            x.ToTable(nameof(Student));
            x.Property(p => p.FirstName).HasMaxLength(50).IsRequired(true);
            x.Property(p => p.LastName).HasMaxLength(50).IsRequired(true);
        });
        modelBuilder.Entity<Enrollment>(x =>
        {
            x.ToTable(nameof(Enrollment));
            x.HasKey(nameof(Enrollment.CourseId), nameof(Enrollment.StudentId));
        });


        base.OnModelCreating(modelBuilder);
    }

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            return;
        }

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await SaveChangesAsync();

            await (_currentTransaction?.CommitAsync() ?? Task.CompletedTask);
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}