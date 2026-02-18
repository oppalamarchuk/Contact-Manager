using System.Globalization;
using ContactManager.BLL.IServices;
using ContactManager.BLL.DTOs;
using CsvHelper;
using CsvHelper.Configuration;

namespace ContactManager.BLL.Services;

public class CsvService : ICsvService
{
    public List<EmployeeDTO> CreateEmpoyees(Stream fileStream)
    {
        using (var reader = new StreamReader(fileStream))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<EmployeeMap>();
            
            return csv.GetRecords<EmployeeDTO>().ToList();        
        } 
    }
}

public class EmployeeMap : ClassMap<EmployeeDTO>
{
    public EmployeeMap()
    {
        base.Map(m => m.Name).Name("Name");
        base.Map(m => m.BirthDate).Name("Date of birth");
        base.Map(m => m.Married).Name("Married");
        base.Map(m => m.Phone).Name("Phone");
        base.Map(m => m.Salary).Name("Salary");
    }
}