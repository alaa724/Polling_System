using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polling.BusinessLogicLayer.ServicesContract;
using Polling.DataAccessLayer;
using Polling.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.BusinessLogicLayer.Services
{
    public class PollService : IPollService
    {
        private readonly IUniteOfWork _unitOfWork;

        public PollService(
            IUniteOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }

        public async Task<IEnumerable<Poll>> GetAllPollsAsync()
        {
            return await _unitOfWork.Polls.GetAllAsync();
        }

        public async Task<Poll> GetPollByIdAsync(int id)
        {
            return await _unitOfWork.Polls.GetByIdAsync(id);
        }
        public async Task AddPollAsync(Poll poll)
        {

            await _unitOfWork.Polls.AddAsync(poll);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdatePollAsync(Poll poll)
        {
            _unitOfWork.Polls.Update(poll);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeletePollAsync(int id)
        {
            var poll = await _unitOfWork.Polls.GetByIdAsync(id);
            if (poll != null)
            {
                _unitOfWork.Polls.Remove(poll);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<Poll?> GetLatestPollAsync()
        {
            return (await _unitOfWork.Polls.GetAllAsync()).OrderByDescending(p => p.Id).FirstOrDefault();
        }

        public async Task AnswerQuestionAsync(int pollId, int questionId, int answerId)
        {
            var poll = await _unitOfWork.Polls.GetByIdAsync(pollId);
            if (poll != null)
            {
                var question = poll.Questions.FirstOrDefault(q => q.Id == questionId);
                if (question != null)
                {
                    _unitOfWork.Polls.Update(poll);
                    await _unitOfWork.SaveAsync();
                }
            }
            _unitOfWork.Polls.Update(poll);
            await _unitOfWork.SaveAsync();
        }
    }
}
