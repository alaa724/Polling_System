using Polling.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.BusinessLogicLayer.Interfaces
{
    public interface IUniteOfWork :IAsyncDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseModel;

        Task<int> Complete();
    }
}
