using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.DataAccessLayer.Models
{
    public class UserAnswer : BaseModel
    {
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        public ApplicationUser User { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }

    }
}
