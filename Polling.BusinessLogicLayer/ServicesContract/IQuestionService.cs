using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questioning.BusinessLogicLayer.ServicesContract
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int id);
        Task SaveAnswersAsync(int pollId, List<Answer> answers);
    }
}
