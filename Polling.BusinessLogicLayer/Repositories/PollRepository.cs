using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Polling.BusinessLogicLayer.Interfaces;
using Polling.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.BusinessLogicLayer.Repositories
{
    public class PollRepository : GenericRepository<Poll>
    {
        public PollRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IEnumerable<Poll>> GetAllAsync()
            => await _dbContext.Set<Poll>().Include(P => P.Questions).AsNoTracking().ToListAsync();

    }
}
