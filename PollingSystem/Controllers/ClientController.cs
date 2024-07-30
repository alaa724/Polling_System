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

        [HttpGet]
        public async Task<IActionResult> AnswerPoll()
        {
            var poll = await _pollService.GetLatestPollAsync();
            if (poll == null)
            {
                return NotFound();
            }

            var viewModel = new UserPollViewModel
            {
                Id = poll.Id,
                PollTitle = poll.Title,
                Questions = poll.Questions.Select(q => new UserQuestionViewModel
                {
                    QuestionId = q.Id,
                    QuestionText = q.Text,
                    Answers = q.Answers.Select(a => new UserAnswerViewModel
                    {
                        AnswerId = a.Id,
                        AnswerText = a.Text,
                        IsSelected = false
                    }).ToList()
                }).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AnswerPoll(UserPollViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var question in model.Questions)
                {
                    var selectedAnswerId = question.Answers.FirstOrDefault(a => a.IsSelected)?.AnswerId;
                    if (selectedAnswerId != null)
                    {
                        await _pollService.SaveAnswerAsync(model.Id, question.QuestionId, selectedAnswerId.Value);
                        StoreAnswerInCookie(model.Id, question.QuestionId, selectedAnswerId.Value);
                    }
                }

                return RedirectToAction("Index");
            }

            return View(model);

        }

        private void StoreAnswerInCookie(int pollId, int questionId, int answerId)
        {
            var cookieKey = $"Poll_{pollId}_Question_{questionId}";
            var cookieValue = answerId.ToString();

            // Store the answer id in a cookie
            Response.Cookies.Append(cookieKey, cookieValue, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30) // Set cookie expiration as needed
            });
        }

        private bool IsAnswerSelected(int pollId, int questionId, int answerId)
        {
            var cookieKey = $"Poll_{pollId}_Question_{questionId}";
            var cookieValue = Request.Cookies[cookieKey];

            return cookieValue != null && cookieValue == answerId.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPollAnswers(UserPollViewModel model)
        {
            if (ModelState.IsValid)
            {
                var poll = await _pollService.GetPollByIdAsync(model.Id);
                if (poll == null)
                {
                    return NotFound();
                }

                foreach (var question in model.Questions)
                {
                    var selectedAnswer = question.Answers.FirstOrDefault(a => a.IsSelected);
                    if (selectedAnswer != null)
                    {
                        var answer = poll.Questions
                            .SelectMany(q => q.Answers)
                            .FirstOrDefault(a => a.Id == selectedAnswer.AnswerId);

                        if (answer != null)
                        {
                            answer.IsSelected = true;
                        }
                    }
                }

                await _pollService.SavePollAsync(poll);

                return RedirectToAction("Index", "Home");
            }

            return View("AnswerPoll", model);
        }

        [HttpGet]
        public async Task<IActionResult> LatestPoll()
        {
            var latestPoll = await _pollService.GetLatestPollAsync();
            return View(latestPoll);
        }


    }
}
