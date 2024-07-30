using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polling.BusinessLogicLayer.ServicesContract;
using Polling.DataAccessLayer.Data;
using PollingSystem.ViewModels;

namespace PollingSystem.Controllers
{
    public class PollController : Controller
    {

        private readonly IPollService _pollService;
        private readonly ILogger<PollController> _logger;

        public PollController(IPollService pollService,
            ILogger<PollController> logger)
        {
            _pollService = pollService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var polls = await _pollService.GetAllPollsAsync();
            return View(polls);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PollViewModel
            {
                Questions = new List<QuestionViewModel>
            {
                new QuestionViewModel
                {
                    Answers = new List<AnswerViewModel>
                    {
                        new AnswerViewModel(),
                        new AnswerViewModel(),
                        new AnswerViewModel()
                    }
                }
            }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PollViewModel model)
        {
            if (ModelState.IsValid)
            {
                var poll = new Poll
                {
                    Title = model.Title,
                    Questions = model.Questions.Select(q => new Question
                    {
                        Text = q.Text,
                        Answers = q.Answers.Select(a => new Answer
                        {
                            Text = a.Text
                        }).ToList()
                    }).ToList()
                };

                await _pollService.SavePollAsync(poll);
                return RedirectToAction("Index", "Home");
            }

            // Reinitialize questions and answers if model state is invalid
            if (model.Questions == null || model.Questions.Count == 0)
            {
                model.Questions = new List<QuestionViewModel>
            {
                new QuestionViewModel
                {
                    Answers = new List<AnswerViewModel>
                    {
                        new AnswerViewModel(),
                        new AnswerViewModel(),
                        new AnswerViewModel()
                    }
                }
            };
            }
            else
            {
                foreach (var question in model.Questions)
                {
                    if (question.Answers == null || question.Answers.Count == 0)
                    {
                        question.Answers = new List<AnswerViewModel>
                    {
                        new AnswerViewModel(),
                        new AnswerViewModel(),
                        new AnswerViewModel()
                    };
                    }
                }
            }

            return View(model);
        }



    }
}
