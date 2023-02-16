using System.ComponentModel.DataAnnotations.Schema;

namespace DIO.AzureHRSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; } //ramal
        public string ProfessionalEmail { get; set; }
        public string Department { get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }
        public DateTimeOffset? AdmissionDate { get; set; }
    }
}