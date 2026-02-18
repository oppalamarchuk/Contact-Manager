using ContactManager.BLL.DTOs;

namespace ContactManager.BLL.IServices;

public interface ICsvService
{
    public List<EmployeeDTO> CreateEmpoyees(Stream fileStream);
}