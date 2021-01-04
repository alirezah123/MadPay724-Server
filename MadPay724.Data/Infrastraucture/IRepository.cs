using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MadPay724.Data.Infrastraucture
{
    public interface IRepository<Tentity> where Tentity:class
    {
        void Insert(Tentity entity);

        void Update(Tentity entity);


        void Delete(object id);


        void Delete(Tentity entity);


        void Delete(Expression<Func<Tentity, bool>> Where);

        Tentity GetBYId(object id);

        IEnumerable<Tentity> GetAll(Tentity entity);

       Tentity Get(Expression<Func<Tentity, bool>> Where);

        IEnumerable<Tentity> GetMany(Expression<Func<Tentity, bool>> Where);



        Task InsertAsync(Tentity entity);


       Task<Tentity> GetBYIdAsync(object id);

        Task<IEnumerable<Tentity>> GetAllAsync(Tentity entity);

        Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> Where);

        Task<IEnumerable<Tentity>> GetManyAsync(Expression<Func<Tentity, bool>> Where);

    }
}
