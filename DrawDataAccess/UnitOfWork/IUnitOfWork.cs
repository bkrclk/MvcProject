using DrawData.Context;
using System;
using WizardDataAccess.Repository;

namespace WizardDataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        MasterContext Context { get; }
        IRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();

    }
}
