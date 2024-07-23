using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;

namespace PollingSystem.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Question/AddToPoll/5
        public ActionResult AddToPoll(int pollId)
        {
            var poll = _dbContext.Polls.Find(pollId);
            if (poll == null)
                return NotFound();

            var question = new Question { PollId = pollId };
            return View(question);
        }

        // POST: Question/AddToPoll/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToPoll(int pollId, Question question)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Questions.Add(question);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home"); // Redirect to home page 
            }

            return View(question);
        }
    }
}
