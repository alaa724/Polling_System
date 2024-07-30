using Polling.DataAccessLayer.Models;

namespace DataAccessLayer.Models
{
    public class Question : BaseModel
    {
        public string Text { get; set; }

        public int PollId { get; set; }
        public Poll Poll { get; set; }
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}
