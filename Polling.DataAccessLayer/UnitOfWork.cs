using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Interfaces;
using Polling.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.DataAccessLayer
{
    public class UnitOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IPollRepository _pollRepository;
        private IQuestionRepository _questionRepository;
        private IAnswerRepository _answerRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPollRepository Polls => _pollRepository ??= new PollRepositoriey(_dbContext);
        public IQuestionRepository Questions => _questionRepository ??= new QuestionRepository(_dbContext);
        public IAnswerRepository Answers => _answerRepository ??= new AnswerRepository(_dbContext);


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
