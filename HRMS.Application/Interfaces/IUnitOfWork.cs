namespace HRMS.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    IRoleRepository RoleRepository { get; }
    IAttendanceRepository AttendanceRepository { get; }
    ILeaveRequestRepository LeaveRequestRepository { get; }
    ISalaryRepository SalaryRepository { get; }

    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}