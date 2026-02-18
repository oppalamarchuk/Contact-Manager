using ContactManager.BLL.DTOs;

namespace ContactManager.BLL.IServices;

public interface IEmployeeService
{
    public Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
    public Task AddRangeEmployeeAsync(IEnumerable<EmployeeDTO> employeesDto);
    public Task DeleteEmployeeAsync(int id);
    public Task UpdateEmployeeAsync(EmployeeDTO employeeDto);
}