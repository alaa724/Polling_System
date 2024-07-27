using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace PollingSystem.ViewModels
{
    public class PollViewModel
    {
        public int PollId { get; set; }
        public string Title { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
