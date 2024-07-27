using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.DataAccessLayer.Interfaces
{
    public interface IUniteOfWork : IDisposable
    {
        IPollRepository Polls { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        Task<int> SaveAsync();
    }
}
