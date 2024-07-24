using DataAccessLayer.Models;
using Polling.BusinessLogicLayer.Interfaces;
using Polling.BusinessLogicLayer.Repositories;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.BusinessLogicLayer
{
    public class UnitOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private Hashtable _repository;

        public UnitOfWork(ApplicationDbContext dbContext) // Ask CLR for creating object from 'DbContext'
        {
            _dbContext = dbContext;

            _repository = new Hashtable();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseModel
        {
            var key = typeof(T).Name; // Poll

            if (!_repository.ContainsKey(key))
            {
                if (key == nameof(Poll))
                {
                    var repo = new PollRepository(_dbContext);
                    _repository.Add(key, repo);
                }
                else
                {
                    var repository = new GenericRepository<T>(_dbContext);
                    _repository.Add(key, repository);
                }

            }
            return _repository[key] as IGenericRepository<T>;
        }
        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync(); // Close The Connection
        }


    }
}
