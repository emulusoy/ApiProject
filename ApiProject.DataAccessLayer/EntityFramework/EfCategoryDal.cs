using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProject.DataAccessLayer.Abstract;
using ApiProject.DataAccessLayer.Context;
using ApiProject.DataAccessLayer.Repositories;
using ApiProject.EntityLayer.Entities;

namespace ApiProject.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(ApiProjectContext context) : base(context)
        {
        }
    }
}
