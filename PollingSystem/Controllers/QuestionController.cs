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


        // GET: Question/Index/5 
        public ActionResult Index(int pollId)
        {
            var questions = _dbContext.Questions.Where(q => q.PollId == pollId).ToList();
            return View(questions);
        }


        // GET: Question/Create
        public ActionResult Create(int pollId)
        {
            Question question = new Question { PollId = pollId };
            return View(question);
        }

        // POST: Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Questions.Add(question);
                _dbContext.SaveChanges();
                return RedirectToAction("AddQuestions", "Polls", new { id = question.PollId });
            }

            return View(question);
        }
    }
}
