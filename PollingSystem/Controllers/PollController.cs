using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;
using PollingSystem.ViewModels;

namespace PollingSystem.Controllers
{
    
    public class PollController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PollController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Poll
        public ActionResult Index()
        {
            var polls = _dbContext.Polls.ToList();
            return View(polls);
        }

        // GET: Poll/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poll/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Poll poll)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Polls.Add(poll);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect to home page 
            }

            return View(poll);
        }

        // GET: Poll/AddQuestions/2
        public ActionResult AddQustions(int id)
        {
            var poll = _dbContext.Polls.Find(id);
            if (poll == null)
                return NotFound();

            return View(poll);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestions(int id, List<Question> questions)
        {
            if (ModelState.IsValid)
            {
                var poll = _dbContext.Polls.Find(id);
                if (poll == null)
                    return NotFound();

                foreach (var question in questions)
                {
                    poll.Questions.Add(question);
                }

                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
