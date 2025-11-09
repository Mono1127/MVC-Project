
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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MVC_ProjectDbContext _context;

        public GenericRepository(MVC_ProjectDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }
        public T? Get(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public int Add(T models)
        {
            _context.Set<T>().Add(models);
            return _context.SaveChanges();
        }
        public int Update(T models)
        {
            _context.Set<T>().Update(models);
            return _context.SaveChanges();
        }

        public int Delete(T models)
        {
            _context.Set<T>().Remove(models);
            return _context.SaveChanges();
        } 
    }
}
