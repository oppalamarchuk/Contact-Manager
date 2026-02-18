using ContactManager.DAL.Entities;
using ContactManager.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.DAL.Repositories;

public class EmployeeRepository(ManagerDbContext context) : IEmployeeRepository
{
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await context.Employees.ToListAsync();
    }

    public async Task AddRangeEmployeeAsync(IEnumerable<Employee> employees)
    {
        await context.AddRangeAsync(employees);
        await context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await context.Employees.Where(e => e.Id == id).ExecuteDeleteAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        context.Employees.Update(employee);
        await context.SaveChangesAsync();
    }
}