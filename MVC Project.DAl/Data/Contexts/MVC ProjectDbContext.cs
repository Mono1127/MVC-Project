using Microsoft.EntityFrameworkCore;
using MVC_Project.DAl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.DAl.Data.Contexts
{
    public class MVC_ProjectDbContext : DbContext
    {
        public MVC_ProjectDbContext(DbContextOptions<MVC_ProjectDbContext>options) : base (options) 
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = .; Database = MVC Project; Trusted_Connection = True; TrustServerCertificate = True ");

        //}
           public DbSet<Department> departments { get; set; }
    }
}
