namespace PollingSystem.ViewModels
{
    public class UserPollViewModel
    {
        public int Id { get; set; }
        public string PollTitle { get; set; }
        public List<UserQuestionViewModel> Questions { get; set; }
    }
}
