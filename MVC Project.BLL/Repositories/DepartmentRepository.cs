using MVC_Project.BLL.Interfaces;
using MVC_Project.DAl.Data.Contexts;
using MVC_Project.DAl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MVC_ProjectDbContext _context;

        public DepartmentRepository(MVC_ProjectDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.departments.ToList();
        }
        public Department? Get(int id)
        {
            return _context.departments.Find(id);
        }
        public int Add(Department models)
        {
            _context.departments.Add(models);
            return _context.SaveChanges();
        }
        public int Update(Department models)
        {
            _context.departments.Update(models);
            return _context.SaveChanges();
        }

        public int Delete(Department models)
        {
            _context.departments.Remove(models);
            return _context.SaveChanges();
        }

    }
}
