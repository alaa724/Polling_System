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

        // GET: Answer/Index
        public ActionResult Index()
        {
            var answers = _dbContext.Answers.Include(a => a.Questions).ToList();
            return View(answers);
        }
    }
}
