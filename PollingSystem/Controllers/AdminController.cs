//using Microsoft.AspNetCore.Mvc;
//using Polling.BusinessLogicLayer.ServicesContract;
//using PollingSystem.ViewModels;

//namespace PollingSystem.Controllers
//{
//    public class AdminController : Controller
//    {

//        private readonly IPollService _pollService;

//        public AdminController(IPollService pollService)
//        {
//            _pollService = pollService;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult CreatePoll()
//        {
//            return View(new PollViewModel
//            {
//                Questions = new List<QuestionViewModel>
//                {
//                    new QuestionViewModel
//                    {
//                        Answers = new List<AnswerViewModel> { new AnswerViewModel(), new AnswerViewModel(), new AnswerViewModel() }
//                    }
//                }
//            });
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreatePoll(PollViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                await _pollService.SavePollAsync();
//                return RedirectToAction("Index", "Home");
//            }

//            return View(model);
//        }
//    }
//}
