using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProject.DataAccessLayer.Abstract;
using ApiProject.DataAccessLayer.Context;

namespace ApiProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ApiProjectContext _context;

        public GenericRepository(ApiProjectContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var val = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(val);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
           _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
