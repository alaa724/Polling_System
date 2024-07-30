using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.DataAccessLayer.Repositories
{
    public class PollRepositoriey : GenericRepository<Poll>, IPollRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PollRepositoriey(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Poll> GetAllWithQuestionsAndAnswers()
        {
            return _dbContext.Polls
                .Include(p => p.Questions)
                .ThenInclude(q => q.Answers);
        }
    }
}
