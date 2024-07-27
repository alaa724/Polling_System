using DataAccessLayer.Models;
using Polling.DataAccessLayer.Interfaces;
using Questioning.BusinessLogicLayer.ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questioning.BusinessLogicLayer.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUniteOfWork _unitOfWork;

        public QuestionService(IUniteOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _unitOfWork.Questions.GetAllAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _unitOfWork.Questions.GetByIdAsync(id);
        }
        public async Task AddQuestionAsync(Question question)
        {
            await _unitOfWork.Questions.AddAsync(question);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            _unitOfWork.Questions.Update(question);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _unitOfWork.Questions.GetByIdAsync(id);
            if (question != null)
            {
                _unitOfWork.Questions.Remove(question);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task SaveAnswersAsync(int pollId, List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                await _unitOfWork.Answers.AddAsync(answer);
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
