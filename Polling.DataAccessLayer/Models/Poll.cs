using Polling.DataAccessLayer.Models;

namespace DataAccessLayer.Models
{
    public class Poll : BaseModel
    {
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
