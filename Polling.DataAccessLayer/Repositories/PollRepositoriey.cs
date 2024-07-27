using DataAccessLayer.Models;
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
        public PollRepositoriey(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
