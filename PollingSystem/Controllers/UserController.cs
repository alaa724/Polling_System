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

       
        // GET: User/LastPoll
        public ActionResult LastPoll()
        {
            var lastPoll = _dbContext.Polls.OrderByDescending(p => p.Id).FirstOrDefault();
            if (lastPoll == null)
                return NotFound();
            return View(lastPoll);
        }

       

    }
}
