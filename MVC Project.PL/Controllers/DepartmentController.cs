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




    }
}
