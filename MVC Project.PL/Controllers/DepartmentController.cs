using Microsoft.AspNetCore.Mvc;
using MVC_Project.BLL.Interfaces;
using MVC_Project.BLL.Repositories;
using MVC_Project.DAl.Models;
using MVC_Project.PL.Dtos;

namespace MVC_Project.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _repository =  departmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            var departments = _repository.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
           if( ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };
               var count =  _repository.Add(department);
                if (count > 0) 
                {
                 return RedirectToAction(nameof(Index));
                }
            }
           return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id,string viewName = "Details" )
        {
            if (id == null) return BadRequest("Invalid Id");

            var department= _repository.Get(id.Value);
            if (department == null) return NotFound();
            return View(viewName, department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id == null ) return BadRequest("Invalid Id");

            //var department = _repository.Get(id.Value);
            //if (department == null) return NotFound();

            return Details(id,"Edit");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id,Department department)
        {
            if (ModelState.IsValid)
            {
                if (id == department.Id)
                {
                    var count = _repository.Update(department);

                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id == null) return BadRequest("Invalid Id");

            //var department = _repository.Get(id.Value);

            //if (department == null) return NotFound();

            return Details(id,"Delete");
        }


        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id == department.Id)
                {
                    var count = _repository.Delete(department);

                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(department);
        }

    }
}
