using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Answering.BusinessLogicLayer.ServicesContract;
using Polling.DataAccessLayer.Interfaces;

namespace Answersing.BusinessLogicLayer.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUniteOfWork _unitOfWork;

        public AnswerService(IUniteOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            return await _unitOfWork.Answers.GetByIdAsync(id);
        }

        public async Task AddAnswerAsync(Answer answer)
        {
            await _unitOfWork.Answers.AddAsync(answer);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAnswerAsync(Answer answer)
        {
            _unitOfWork.Answers.Update(answer);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAnswerAsync(int id)
        {
            var answer = await _unitOfWork.Answers.GetByIdAsync(id);
            if (answer != null)
            {
                _unitOfWork.Answers.Remove(answer);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
