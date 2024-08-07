﻿using Polling.DataAccessLayer.Models;

namespace DataAccessLayer.Models
{
    public class Answer : BaseModel
    {
        public string Text { get; set; }

        public bool IsSelected { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } 
    }
}
