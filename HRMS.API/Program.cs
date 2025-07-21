using HRMS.Application.Interfaces;
using HRMS.Application.Mappings;
using HRMS.Infrastructure.Data;
using HRMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework
builder.Services.AddDbContext<HRMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MediatR
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssemblies(
        typeof(HRMS.Application.Features.Employees.Commands.CreateEmployee.CreateEmployeeCommand).Assembly
    );
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Repository Pattern and Unit of Work
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HRMSDbContext>();
    context.Database.EnsureCreated();
}

app.Run();