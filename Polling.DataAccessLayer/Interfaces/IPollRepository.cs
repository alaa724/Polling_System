using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.DataAccessLayer.Interfaces
{
    public interface IPollRepository : IGenericRepository<Poll>
    {
    }
}
