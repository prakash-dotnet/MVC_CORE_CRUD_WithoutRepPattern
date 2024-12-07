using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace MVC_CORE_CRUD_WithoutRepPattern.Models
{
    public class EmployeeDbContext :DbContext 
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
