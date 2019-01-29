using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDemo.BusinessObjects;
using EFCoreDemo.DataAccess;

namespace EFCoreDemo.BusinessEntityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EfdemoContext _context;

        public EmployeesController(EfdemoContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/EmployeeCode
        [HttpGet("{employeeCode}")]
        public async Task<ActionResult<Employee>> GetEmployee(string employeeCode)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeCode == employeeCode);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/EmployeeCode
        [HttpPut("{employeeCode}")]
        public async Task<IActionResult> PutEmployee(string employeeCode, Employee employee)
        {
            if (employeeCode != employee.EmployeeCode)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employeeCode))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { EmployeeCode = employee.EmployeeCode }, employee);
        }

        // DELETE: api/Employees/EmployeeCode
        [HttpDelete("{employeeCode}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(string employeeCode)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeCode == employeeCode);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(string employeeCode)
        {
            return _context.Employees.Any(e => e.EmployeeCode == employeeCode);
        }
    }
}
