using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastraucture
{
    public abstract class Repository<Tentity> : IRepository<Tentity>, IDisposable where Tentity : class
    {
        #region ctor
        private readonly DbContext _db;
        private readonly DbSet<Tentity> _dbset;

        public Repository(DbContext db)
        {
            _db = db;
            _dbset = _db.Set<Tentity>();
        }

        #endregion
        #region normal
        public void Insert(Tentity entity)
        {
            _dbset.Add(entity);
        }
        public void Update(Tentity entity)
        {
            if (entity == null)
                throw new ArgumentException("there is no entity");
            _dbset.Update(entity);

        }
        public void Delete(object id)
        {
            var entity = GetBYId(id);
            if (entity == null)
                throw new ArgumentException("there is no entity");
            _dbset.Remove(entity);
        }
        public void Delete(Tentity entity)
        {
            _dbset.Remove(entity);
           
        }
        public void Delete(Expression<Func<Tentity, bool>> Where)
        {
            IEnumerable<Tentity> objs = _dbset.Where(Where).AsQueryable();
            foreach (Tentity item in objs)
            {
                _dbset.Remove(item);
            }
        }
        public Tentity GetBYId(object id)
        {
            return _dbset.Find(id);
        }   
        public IEnumerable<Tentity> GetAll(Tentity entity)
        {
            return _dbset.AsEnumerable();
        }
        public Tentity Get(Expression<Func<Tentity, bool>> Where)
        {
            return _dbset.Where(Where).FirstOrDefault();
        }
        public IEnumerable<Tentity> GetMany(Expression<Func<Tentity, bool>> Where)
        {
            return _dbset.Where(Where).AsQueryable(); ;
        }
        #endregion


        #region Async
        public async Task InsertAsync(Tentity entity)
        {
           await _dbset.AddAsync(entity);
        }
       
        public async Task<Tentity> GetBYIdAsync(object id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task<IEnumerable<Tentity>> GetAllAsync(Tentity entity)
        {
            return await _dbset.ToListAsync();
        }
        public async Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> Where)
        {
            return await _dbset.Where(Where).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Tentity>> GetManyAsync(Expression<Func<Tentity, bool>> Where)
        {
            return await _dbset.Where(Where).ToListAsync(); ;
        }



        #endregion

        #region dispose

        private bool dispose = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
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

        ~Repository()
        {
            Dispose(false);
        }
        #endregion
    }
}
