using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Models;

namespace PollingSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var polls = _dbContext.Polls.ToList();

            return View(polls);
        }

        public ActionResult LastPoll()
        {
            var lastPoll = _dbContext.Polls.OrderByDescending(p => p.Id).FirstOrDefault();

            if (lastPoll == null) return NotFound();

            return View(lastPoll);
        }

        [HttpGet]
        public ActionResult SelectAnswer(int pollId, int questionId)
        {
            var poll = _dbContext.Polls.Find(pollId);
            if (poll == null)
                return NotFound();

            var question = poll.Questions.FirstOrDefault(q => q.Id == questionId);
            if (question == null)
                return NotFound();

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectedAnswer(int questionId, int answerId)
        {
            var question = _dbContext.Questions.Find(questionId);
            if (question == null)
                return NotFound();

            var answer = question.Answers.FirstOrDefault(a => a.Id == answerId);
            if (answer == null)
                return NotFound();

            var userAnswer = new UserAnswer
            {
                UserId = User.Identity?.Name ?? "NA",
                QuestionId = questionId,
                AnswerId = answerId
            };

            return RedirectToAction("Index");
        }

    }
}
