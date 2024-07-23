using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace PollingSystem.ViewModels
{
    public class PollViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title is required !) ")]
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
