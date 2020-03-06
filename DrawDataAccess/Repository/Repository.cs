using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WizardDataAccess.UnitOfWork;

namespace WizardDataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork UnitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Add(T model)
        {
            if (model != null) UnitOfWork.Context.Add(model);
        }

        public void AddRange(List<T> models)
        {
            if (models != null) UnitOfWork.Context.AddRange(models);
        }

        public void Delete(int id)
        {
            if (id == 0) return;
            UnitOfWork.Context.Remove(UnitOfWork.Context.Find<T>(id));
        }
        
        public IQueryable<T> GetAll()
        {
            return UnitOfWork.Context.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return UnitOfWork.Context.Set<T>().AsQueryable().Where(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return UnitOfWork.Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return id != 0 ? UnitOfWork.Context.Find<T>(id) : null;
        }

        public void Update(T model)
        {
            if (model != null) UnitOfWork.Context.Entry(model).State = EntityState.Modified;
        }
    }
}