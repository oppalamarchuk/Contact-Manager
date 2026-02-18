using ContactManager.DAL.Entities;
using ContactManager.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ContactManager.DAL.Repositories;

public class EmployeeRepository(ManagerDbContext context, ILogger<EmployeeRepository> logger) 
    : IEmployeeRepository
{
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await context.Employees.AsNoTracking().ToListAsync();
    }

    public async Task AddRangeEmployeeAsync(IEnumerable<Employee> employees)
    {
        var employeeList = employees.ToList();
        if (employeeList.Count == 0)
        { 
            logger.LogInformation("Employees collection was empty");
            return;
        }
        
        context.Employees.AddRange(employeeList);
        await context.SaveChangesAsync();
        
        logger.LogInformation("Employees created : {0}", employeeList.Count());
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var deletedCount = await context.Employees.Where(e => e.Id == id).ExecuteDeleteAsync();

        if (deletedCount > 0)
        {
            logger.LogInformation("Employee {0} deleted", id);
        }
        else
        {
            logger.LogError("Attempted to delete employee {0}, but they weren't found", id);
            throw new KeyNotFoundException($"employee with id {id} weren't found");
        }
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        context.Employees.Update(employee);
        await context.SaveChangesAsync();
        
        logger.LogInformation("Employee {0} updated", employee.Id);
    }
}