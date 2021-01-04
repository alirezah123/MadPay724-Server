using MadPay724.Data.Repositories.Interface;
using MadPay724.Data.Repositories.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastraucture
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region ctor
        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }
        #endregion
        #region privateRepository
        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_db);
                }
                return userRepository;
            }
        }
        #endregion

        #region Save
        public void Save()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();

        }
        #endregion
        #region dispose
        private bool dispose = false;

       

        protected virtual void Dispose(bool disposing)
        {
            if(!dispose)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
      ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
