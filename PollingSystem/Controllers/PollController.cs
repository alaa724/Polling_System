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
            return View(new PollViewModel());
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
                        Answers = q.Answers.Select(a => new Answer { Text = a.Text}).ToList()
                    }).ToList()
                };
                await _pollService.AddPollAsync(poll);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        
    }
}
