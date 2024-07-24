using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Polling.BusinessLogicLayer.Interfaces;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.BusinessLogicLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public void Add(T entity)

            => _dbContext.Set<T>().Add(entity);

        public void Update(T entity)
            => _dbContext.Set<T>().Update(entity);


        public void Delete(T entity)
            => _dbContext.Set<T>().Remove(entity);

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Poll))
                return (IEnumerable<T>)await _dbContext.Polls.Include(P => P.Questions).AsNoTracking().ToListAsync();
            else
                return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }


    }
}
