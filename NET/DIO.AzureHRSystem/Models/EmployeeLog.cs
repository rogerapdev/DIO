using Azure;
using Azure.Data.Tables;
using System.Text.Json;

using DIO.AzureHRSystem.Enums;

namespace DIO.AzureHRSystem.Models
{
    public class EmployeeLog : Employee, ITableEntity
    {
        public ActionType ActionType { get; set; }
        public string JSON { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public EmployeeLog() { }

        public EmployeeLog(Employee employee, ActionType actionType, string partitionKey, string rowKey)
        {
            base.Id = employee.Id;
            base.Name = employee.Name;
            base.Address = employee.Address;
            base.Branch = employee.Branch;
            base.ProfessionalEmail = employee.ProfessionalEmail;
            base.Department = employee.Department;
            base.Salary = employee.Salary;
            base.AdmissionDate = employee.AdmissionDate;
            ActionType = actionType;
            JSON = JsonSerializer.Serialize(employee);
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }


    }
}