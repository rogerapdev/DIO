using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;

using DIO.AzureHRSystem.Enums;
using DIO.AzureHRSystem.Context;
using DIO.AzureHRSystem.Models;

namespace DIO.AzureHRSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly HRContext _context;
        private readonly string _connectionString;
        private readonly string _tableName;

        public EmployeeController(HRContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetValue<string>("ConnectionStrings:SAConnectionString");
            _tableName = configuration.GetValue<string>("ConnectionStrings:AzureTableName");
        }


        private TableClient GetTableClient()
        {
            TableServiceClient serviceClient = new TableServiceClient(_connectionString);
            TableClient tableClient = serviceClient.GetTableClient(_tableName);

            tableClient.CreateIfNotExists();

            return tableClient;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Employee employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            var tableClient = GetTableClient();
            var employeeLog = new EmployeeLog(employee, ActionType.Inclusion, employee.Department, Guid.NewGuid().ToString());

            tableClient.UpsertEntity(employeeLog);

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            Employee employeeDatabase = _context.Employees.Find(id);

            if (employeeDatabase == null)
            {
                return NotFound();
            }

            employeeDatabase.Name = employee.Name;
            employeeDatabase.Branch = employee.Branch;
            employeeDatabase.Department = employee.Department;
            employeeDatabase.Address = employee.Address;
            employeeDatabase.ProfessionalEmail = employee.ProfessionalEmail;
            employeeDatabase.Salary = employee.Salary;
            _context.SaveChanges();

            var tableClient = GetTableClient();
            var employeeLog = new EmployeeLog(employeeDatabase, ActionType.Update, employeeDatabase.Department, Guid.NewGuid().ToString());

            tableClient.UpsertEntity(employeeLog);

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employee employeeDatabase = _context.Employees.Find(id);

            if (employeeDatabase == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employeeDatabase);
            _context.SaveChanges();

            var tableClient = GetTableClient();
            var employeeLog = new EmployeeLog(employeeDatabase, ActionType.Removal, employeeDatabase.Department, Guid.NewGuid().ToString());

            tableClient.UpsertEntity(employeeLog);

            return NoContent();
        }
    }
}