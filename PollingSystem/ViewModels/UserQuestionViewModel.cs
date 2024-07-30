namespace PollingSystem.ViewModels
{
    public class UserQuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<UserAnswerViewModel> Answers { get; set; }
    }
}