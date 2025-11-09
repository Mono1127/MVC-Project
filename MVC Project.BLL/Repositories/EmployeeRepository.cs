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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MVC_ProjectDbContext context) : base(context)
        {
            
        }

    }
}
