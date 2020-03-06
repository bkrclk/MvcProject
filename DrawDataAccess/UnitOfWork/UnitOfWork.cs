using DrawData.Context;
using System;
using WizardDataAccess.Repository;

namespace WizardDataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public MasterContext Context { get; }

        public UnitOfWork(MasterContext dbContext) => Context = dbContext;

        public IRepository<T> GetRepository<T>() where T : class => new Repository<T>(this);

        public void SaveChanges() => Context.SaveChanges();

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
