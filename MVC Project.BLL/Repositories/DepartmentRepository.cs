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
    public class DepartmentRepository : GenericRepository<Department> ,IDepartmentRepository
    {
        public DepartmentRepository(MVC_ProjectDbContext context) : base (context)
        {
            
        }

    }
}
