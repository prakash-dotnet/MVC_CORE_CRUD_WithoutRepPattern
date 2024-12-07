using System.ComponentModel.DataAnnotations;

namespace MVC_CORE_CRUD_WithoutRepPattern.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
