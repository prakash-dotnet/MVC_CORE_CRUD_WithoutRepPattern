using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CORE_CRUD_WithoutRepPattern.Models;
using System;

namespace MVC_CORE_CRUD_WithoutRepPattern.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View( );
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Employee added successfully";
            }
            return View(emp);
        }
        public IActionResult Delete(int ?id)
        {
            if(id==null)
                return NotFound();
            var emp= _context.Employees.FirstOrDefault(e=>e.EmployeeId==id);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
                var employee = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
                var emp = await _context.Employees.FindAsync(employee.EmployeeId);
                if(emp == null)
                return NotFound();
                else
                {
                    emp.Name = employee.Name;
                    emp.Salary = employee.Salary;
                    _context.Employees.Update(emp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            return View(emp);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Details(Employee employee)
        {
            var emp = await _context.Employees.FindAsync(employee.EmployeeId);
            if (emp == null)
                return NotFound();
            return View(emp);
        }
    }


}
 

