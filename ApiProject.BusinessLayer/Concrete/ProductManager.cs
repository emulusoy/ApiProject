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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id); 
        }

        public Product TGetById(int id)
        {
           return _productDal.GetById(id);  
        }

        public List<Product> TGetListAll()
        {
           return _productDal.GetListAll(); 
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
