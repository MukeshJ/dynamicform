using AutoMapper;
using HRMS.Application.DTOs;
using HRMS.Application.Features.Employees.Commands.CreateEmployee;
using HRMS.Domain.Entities;

namespace HRMS.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Employee mappings
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : string.Empty))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name : string.Empty));
        
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();

        // Salary mappings
        CreateMap<Salary, SalaryDto>()
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => 
                src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : string.Empty));
        
        CreateMap<CreateSalaryDto, Salary>()
            .ForMember(dest => dest.GrossSalary, opt => opt.MapFrom(src => src.BasicSalary + (src.Allowances ?? 0)))
            .ForMember(dest => dest.NetSalary, opt => opt.MapFrom(src => src.BasicSalary + (src.Allowances ?? 0) - (src.Deductions ?? 0)))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

        CreateMap<UpdateSalaryDto, Salary>()
            .ForMember(dest => dest.GrossSalary, opt => opt.MapFrom(src => src.BasicSalary + (src.Allowances ?? 0)))
            .ForMember(dest => dest.NetSalary, opt => opt.MapFrom(src => src.BasicSalary + (src.Allowances ?? 0) - (src.Deductions ?? 0)));

        // Department mappings
        CreateMap<Department, DepartmentDto>();
        CreateMap<CreateDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDto, Department>();

        // Role mappings
        CreateMap<Role, RoleDto>();
        CreateMap<CreateRoleDto, Role>();
        CreateMap<UpdateRoleDto, Role>();

        // Attendance mappings
        CreateMap<Attendance, AttendanceDto>()
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => 
                src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : string.Empty));
        
        CreateMap<CreateAttendanceDto, Attendance>();
        CreateMap<UpdateAttendanceDto, Attendance>();

        // Leave Request mappings
        CreateMap<LeaveRequest, LeaveRequestDto>()
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => 
                src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : string.Empty))
            .ForMember(dest => dest.ApprovedByName, opt => opt.MapFrom(src => 
                src.ApprovedBy != null ? $"{src.ApprovedBy.FirstName} {src.ApprovedBy.LastName}" : string.Empty));
        
        CreateMap<CreateLeaveRequestDto, LeaveRequest>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Domain.Enums.LeaveStatus.Pending));
        
        CreateMap<UpdateLeaveRequestDto, LeaveRequest>();
    }
}