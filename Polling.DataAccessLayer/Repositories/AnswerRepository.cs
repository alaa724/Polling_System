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
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
