using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WizardDataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Add(T model);
        void AddRange(List<T> models);
        void Update(T model);
        void Delete(int id);
    }
}