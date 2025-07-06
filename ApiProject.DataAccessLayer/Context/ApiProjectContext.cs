using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProject.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.DataAccessLayer.Context
{
    public class ApiProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MULUSOY\\SQLEXPRESS01;Initial Catalog=ApiProjectDb;integrated security=True;trust server certificate=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
