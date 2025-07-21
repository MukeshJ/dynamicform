# HRMS (Human Resource Management System) Backend API

A comprehensive .NET 8 Web API for Human Resource Management System built with Clean Architecture, MediatR (CQRS pattern), Repository Pattern, and Unit of Work pattern.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with the following layers:

### 📁 Project Structure

```
HRMS/
├── HRMS.Domain/           # Domain Layer (Entities, Enums, Domain Logic)
├── HRMS.Application/      # Application Layer (DTOs, Commands, Queries, Interfaces)
├── HRMS.Infrastructure/   # Infrastructure Layer (EF Core, Repositories, Data Access)
└── HRMS.API/             # Presentation Layer (Controllers, API Configuration)
```

## 🚀 Features

### Core Modules

1. **👥 Employee Management**
   - Create, Read, Update, Delete employees
   - Employee search and filtering
   - Employee status management

2. **🏢 Department Management**
   - Department CRUD operations
   - Department-Employee relationships
   - Manager assignments

3. **🔐 Role & Permissions**
   - Role-based access control
   - Permission management
   - Employee role assignments

4. **📅 Attendance Tracking**
   - Daily attendance recording
   - Check-in/Check-out times
   - Attendance status tracking

5. **🏖️ Leave Management**
   - Leave request submission
   - Approval/Rejection workflow
   - Leave type management

6. **💰 Salary Management**
   - Employee salary records
   - Salary history tracking
   - Allowances and deductions
   - Active salary management

## 🛠️ Technologies Used

- **.NET 8** - Web API Framework
- **Entity Framework Core** - ORM with SQL Server
- **MediatR** - CQRS Pattern Implementation
- **AutoMapper** - Object-Object Mapping
- **Repository Pattern** - Data Access Abstraction
- **Unit of Work Pattern** - Transaction Management
- **Swagger/OpenAPI** - API Documentation

## 📋 Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or Full SQL Server)
- Visual Studio 2022 or VS Code

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd HRMS
```

### 2. Update Connection String

Update the connection string in `HRMS.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HRMSDB;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }
}
```

### 3. Build and Run

```bash
# Build the solution
dotnet build

# Run the API
cd HRMS.API
dotnet run
```

### 4. Access the API

- **Swagger UI**: `https://localhost:7xxx/swagger`
- **API Base URL**: `https://localhost:7xxx/api`

## 📊 Database Schema

The system includes the following main entities:

- **Employee** - Core employee information
- **Department** - Organizational departments
- **Role** - User roles and permissions
- **Attendance** - Daily attendance records
- **LeaveRequest** - Leave applications and approvals
- **Salary** - Employee salary information

## 🔧 API Endpoints

### Employees
- `POST /api/employees` - Create employee
- `GET /api/employees` - Get all employees
- `GET /api/employees/{id}` - Get employee by ID
- `PUT /api/employees/{id}` - Update employee
- `DELETE /api/employees/{id}` - Delete employee

### Salaries
- `POST /api/salaries` - Create salary record
- `GET /api/salaries/{id}` - Get salary by ID
- `GET /api/salaries/employee/{employeeId}` - Get employee salary history
- `GET /api/salaries/employee/{employeeId}/active` - Get active salary
- `PUT /api/salaries/{id}` - Update salary

## 💡 Usage Examples

### Creating an Employee

```json
POST /api/employees
{
  "employeeId": "EMP001",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@company.com",
  "phoneNumber": "+1234567890",
  "dateOfBirth": "1990-01-15",
  "hireDate": "2024-01-01",
  "position": "Software Developer",
  "status": 1,
  "address": "123 Main St, City, State",
  "departmentId": "guid-here",
  "roleId": "guid-here"
}
```

### Creating a Salary Record

```json
POST /api/salaries
{
  "employeeId": "guid-here",
  "basicSalary": 75000.00,
  "allowances": 5000.00,
  "deductions": 2000.00,
  "effectiveDate": "2024-01-01",
  "comments": "Initial salary setup"
}
```

## 🏗️ Design Patterns Implemented

### 1. **CQRS with MediatR**
- Commands for write operations
- Queries for read operations
- Handlers for business logic

### 2. **Repository Pattern**
- Generic repository for common operations
- Specific repositories for entity-specific operations
- Interface-based design for testability

### 3. **Unit of Work Pattern**
- Transaction management
- Coordinated repository operations
- Rollback capabilities

### 4. **Clean Architecture**
- Domain-driven design
- Dependency inversion
- Separation of concerns

## 🔍 Key Features

- **Soft Delete**: Entities are marked as deleted rather than physically removed
- **Audit Trail**: CreatedAt and UpdatedAt timestamps on all entities
- **Transaction Support**: Unit of Work ensures data consistency
- **Validation**: Input validation at multiple layers
- **Error Handling**: Comprehensive error handling and logging
- **Swagger Documentation**: Auto-generated API documentation

## 🧪 Testing

The architecture supports easy unit testing:

- Repository interfaces can be mocked
- MediatR handlers can be tested in isolation
- Domain logic is separated from infrastructure concerns

## 📈 Future Enhancements

- JWT Authentication & Authorization
- Role-based API access control
- Advanced reporting features
- Email notifications for leave approvals
- Performance monitoring and logging
- Caching implementation
- API versioning

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is licensed under the MIT License.

---

**Built with ❤️ using .NET 8 and Clean Architecture principles**

