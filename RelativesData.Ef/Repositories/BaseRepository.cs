using RelativesData.Core.Repositories;
using RepoPattern2.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RelativesData.Ef.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T :class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Criteria)
        {
            return _context.Set<T>().Where( Criteria).ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
           _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }


    }
}
