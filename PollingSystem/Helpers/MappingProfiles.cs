using AutoMapper;
using DataAccessLayer.Models;
using PollingSystem.ViewModels;

namespace PollingSystem.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PollViewModel, Poll>().ReverseMap();

            CreateMap<UserPollViewModel, Poll>().ReverseMap();

            CreateMap<QuestionViewModel , Question>().ReverseMap();
            CreateMap<UserQuestionViewModel , Question>().ReverseMap();

            CreateMap<AnswerViewModel , Answer>().ReverseMap();
            CreateMap<UserAnswerViewModel , Answer>().ReverseMap();
        }
    }
}
