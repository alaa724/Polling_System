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
                return RedirectToAction("Index", "Home"); // Redirect to home page or desired action
            }

            return View(poll);
        }

        // GET: Poll/Results
        public ActionResult Results()
        {
            var polls = _dbContext.Polls.Include(p => p.Questions).ToList();
            return View(polls);
        }
    }
}
