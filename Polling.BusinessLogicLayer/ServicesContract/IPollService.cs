using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.BusinessLogicLayer.ServicesContract
{
    public interface IPollService
    {
        Task<IEnumerable<Poll>> GetAllPollsAsync();
        Task<Poll> GetPollByIdAsync(int id);
        Task<Poll?> GetLatestPollAsync();
        Task AddPollAsync(Poll poll);
        Task UpdatePollAsync(Poll poll);
        Task DeletePollAsync(int id);
        Task AnswerQuestionAsync(int pollId, int questionId, int answerId);
    }
}
