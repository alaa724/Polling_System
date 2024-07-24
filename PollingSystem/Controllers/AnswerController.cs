using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Models;

namespace PollingSystem.Controllers
{
    public class AnswerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AnswerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        // GET: Answers/Create
        public ActionResult Create(int questionId)
        {
            var answer = new Answer { QuestionId = questionId };
            return View(answer);
        }

        // POST: Answers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Answer answer)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Answers.Add(answer);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Questions", new 
                { 
                    pollId = _dbContext.Questions.Find(answer.QuestionId).PollId 
                });
            }

            return View(answer);
        }
    }
}
