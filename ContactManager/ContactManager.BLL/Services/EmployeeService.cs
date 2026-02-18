using ContactManager.BLL.DTOs;
using ContactManager.BLL.IServices;
using ContactManager.DAL.Entities;
using ContactManager.DAL.IRepositories;

namespace ContactManager.BLL.Services;

public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
{
    public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
    {
        var employees = await repository.GetAllEmployeesAsync();
        return employees.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                BirthDate = e.BirthDate,
                Married = e.Married,
                Name = e.Name,
                Phone = e.Phone,
                Salary = e.Salary
            }).ToList();
    }

    public async Task AddRangeEmployeeAsync(IEnumerable<EmployeeDTO> employeesDtos)
    {
        var employees = employeesDtos
            .Select(e => new Employee
            {
                Id = e.Id,
                BirthDate = e.BirthDate,
                Married = e.Married,
                Name = e.Name,
                Phone = e.Phone,
                Salary = e.Salary
            });
            
        await repository.AddRangeEmployeeAsync(employees);
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await repository.DeleteEmployeeAsync(id);
    }

    public async Task UpdateEmployeeAsync(EmployeeDTO employeeDto)
    {
        var employee = new Employee()
        {
            Id = employeeDto.Id,
            BirthDate = employeeDto.BirthDate,
            Married = employeeDto.Married,
            Name = employeeDto.Name,
            Phone = employeeDto.Phone,
            Salary = employeeDto.Salary
        };
        await repository.UpdateEmployeeAsync(employee);
    }
}