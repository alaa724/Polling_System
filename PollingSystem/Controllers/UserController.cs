using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polling.DataAccessLayer.Data;
using Polling.DataAccessLayer.Models;

namespace PollingSystem.Controllers
{
    [Authorize(Roles = "User")]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        // GET: User/LastPoll
        public ActionResult LastPoll()
        {
            var lastPoll = _dbContext.Polls.Include(p => p.Questions.Select(q => q.Answers)).OrderByDescending(p => p.Id).FirstOrDefault();

            if (lastPoll == null)
            {
                return Content("No polls available.");
            }

            return View(lastPoll);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnswerQuestion(int questionId, int answerId)
        {
            var question = _dbContext.Questions.Find(questionId);
            var answer = _dbContext.Answers.Find(answerId);

            if (question == null || answer == null)
                return NotFound();

            var existingAnswer = _dbContext.Answers.FirstOrDefault(ua => ua.QuestionId == questionId);

            if (existingAnswer != null)
            {
                return Content("You have already answered this question.");
            }

            // Save the client's answer
            var userAnswer = new UserAnswer
            {
                QuestionId = questionId,
                AnswerId = answerId,
                UserId = User.Identity?.Name?? "NA"
            };

            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();

            // Redirect to a thank you page 
            return RedirectToAction("ThankYou", "User");
        }
    }



}
