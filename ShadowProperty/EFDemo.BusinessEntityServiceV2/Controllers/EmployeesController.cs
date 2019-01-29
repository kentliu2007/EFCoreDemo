using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EFDemo.DataAccessV2;

namespace EFDemo.BusinessEntityServiceV2.Controllers
{
    public class EmployeesController : ApiController
    {
        private EFDemoEntities db = new EFDemoEntities();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/Employees/EmployeeCode
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(string code)
        {
            Employee employee = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeCode == code);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/EmployeeCode
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(string code, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (code != employee.EmployeeCode)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { code = employee.EmployeeCode }, employee);
        }

        // DELETE: api/Employees/EmployeeCode
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(string code)
        {
            Employee employee = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeCode == code);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(string employeeCode)
        {
            return db.Employees.Count(e => e.EmployeeCode == employeeCode) > 0;
        }
    }
}