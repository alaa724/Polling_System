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
        }
    }
}
