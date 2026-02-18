using ContactManager.DAL.Entities;

namespace ContactManager.DAL.IRepositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task AddRangeEmployeeAsync(IEnumerable<Employee> employees);
    Task DeleteEmployeeAsync(int id);
    Task UpdateEmployeeAsync(Employee employee);
}