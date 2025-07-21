using HRMS.Application.Interfaces;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRMS.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly HRMSDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(HRMSDbContext context)
    {
        _context = context;
        EmployeeRepository = new EmployeeRepository(_context);
        DepartmentRepository = new DepartmentRepository(_context);
        RoleRepository = new RoleRepository(_context);
        AttendanceRepository = new AttendanceRepository(_context);
        LeaveRequestRepository = new LeaveRequestRepository(_context);
        SalaryRepository = new SalaryRepository(_context);
    }

    public IEmployeeRepository EmployeeRepository { get; }
    public IDepartmentRepository DepartmentRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IAttendanceRepository AttendanceRepository { get; }
    public ILeaveRequestRepository LeaveRequestRepository { get; }
    public ISalaryRepository SalaryRepository { get; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}