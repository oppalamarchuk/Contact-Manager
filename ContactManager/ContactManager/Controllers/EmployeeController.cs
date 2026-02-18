using ContactManager.BLL.DTOs;
using ContactManager.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers;

public class EmployeeController(
    ICsvService csvService,
    IEmployeeService employeeService,
    ILogger<EmployeeController> logger) : Controller
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
            TempData["FileError"] = "Please select a file to upload";
            return RedirectToAction(nameof(Index));
        }

        var empDtos = csvService.CreateEmpoyees(file.OpenReadStream());
        
        await employeeService.AddRangeEmployeeAsync(empDtos);
        
        return RedirectToAction(nameof(Index));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]int id)
    {
        try 
        {
            await employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            logger.LogError("Attempted to delete employee {0}, but they weren't found", id);
            return NotFound($"Employee with ID {id} not found.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting employee {Id}", id);
            return BadRequest("Could not delete employee.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EmployeeDTO empDto)
    {
        await employeeService.UpdateEmployeeAsync(empDto);
        
        return Ok();
    }
}