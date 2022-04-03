using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RelativesData.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
       
        IEnumerable<T> GetAll(Expression<Func<T, bool>> Criteria);

        
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        IEnumerable<T> AddRange(IEnumerable<T>  entities);


    }



}
