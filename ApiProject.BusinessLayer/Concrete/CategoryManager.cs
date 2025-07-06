using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProject.BusinessLayer.Abstract;
using ApiProject.DataAccessLayer.Abstract;
using ApiProject.EntityLayer.Entities;

namespace ApiProject.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TAdd(Category entity)
        {
             _categoryDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
           return _categoryDal.GetListAll();
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
