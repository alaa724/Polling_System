using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Polling.BusinessLogicLayer.ServicesContract;
using PollingSystem.ViewModels;
using Questioning.BusinessLogicLayer.ServicesContract;

namespace PollingSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IPollService _pollService;
        private readonly IQuestionService _questionService;

        public ClientController(IPollService pollService, IQuestionService questionService)
        {
            _pollService = pollService;
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> LatestPoll()
        {
            var latestPoll = await _pollService.GetLatestPollAsync();
            return View(latestPoll);
        }

        [HttpGet]
        public async Task<IActionResult> AnswerPoll(int id)
        {
            var poll = await _pollService.GetPollByIdAsync(id);
            var viewModel = new PollViewModel
            {
                PollId = poll.Id,
                Title = poll.Title,
                Questions = poll.Questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Text = q.Text,
                    Answers = q.Answers.Select(a => new AnswerViewModel
                    {
                        Id = a.Id,
                        Text = a.Text,
                        IsSelected = a.IsSelected
                    }).ToList()
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AnswerPoll(int pollId, int questionId, int answerId)
        {
            await _pollService.AnswerQuestionAsync(pollId, questionId, answerId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var polls = await _pollService.GetAllPollsAsync();
            var viewModel = polls.Select(p => new PollViewModel
            {
                PollId = p.Id,
                Title = p.Title,
                Questions = p.Questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Text = q.Text,
                    Answers = q.Answers.Select(a => new AnswerViewModel
                    {
                        Id = a.Id,
                        Text = a.Text,
                        IsSelected = a.IsSelected
                    }).ToList()
                }).ToList()
            }).ToList();

            return View(viewModel);
        }
    }
}
