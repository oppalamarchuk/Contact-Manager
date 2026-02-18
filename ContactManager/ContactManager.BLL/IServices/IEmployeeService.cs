using ContactManager.BLL.DTOs;

namespace ContactManager.BLL.IServices;

public interface IEmployeeService
{
    public Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
    public Task AddRangeEmployeeAsync(IEnumerable<EmployeeDTO> employees);
}