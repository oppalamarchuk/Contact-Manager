using ContactManager.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers;

public class EmployeeController(ICsvService csvService , IEmployeeService employeeService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var employees = await employeeService.GetAllEmployeesAsync();
        
        return View(employees);
    }
    
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile? file)
    {
        if (file == null || file.Length == 0)
        {
            return RedirectToAction(nameof(Index));
        }

        var empDtos = csvService.CreateEmpoyees(file.OpenReadStream());
        
        await employeeService.AddRangeEmployeeAsync(empDtos);
        
        return RedirectToAction(nameof(Index));
    }
}