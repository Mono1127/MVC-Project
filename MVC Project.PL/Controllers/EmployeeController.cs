using Microsoft.AspNetCore.Mvc;
using MVC_Project.BLL.Interfaces;
using MVC_Project.DAl.Models;
using MVC_Project.PL.Dtos;

namespace MVC_Project.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var employees = _repository.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    CreateAt = model.CreateAt,
                    HiringDate = model.HiringDate,
                    Email = model.Email,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    Phone = model.Phone,
                    Salary = model.Salary
                };
                var count = _repository.Add(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id == null) return BadRequest("Invalid Id");

            var employee = _repository.Get(id.Value);
            if (employee == null) return NotFound();
            return View(viewName, employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id == null ) return BadRequest("Invalid Id");

            //var department = _repository.Get(id.Value);
            //if (department == null) return NotFound();

            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id == employee.Id)
                {
                    var count = _repository.Update(employee);

                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id == null) return BadRequest("Invalid Id");

            //var department = _repository.Get(id.Value);

            //if (department == null) return NotFound();

            return Details(id, "Delete");
        }


        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id == employee.Id)
                {
                    var count = _repository.Delete(employee);

                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(employee);
        }
    }
}
