using AutoMapper;
using TaskList.BLL.Interface.Dtos;
using TaskList.DAL.Interface.Models;

namespace TaskList_API.Config
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<CurrentTaskList, TaskListResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCurrentTaskList.UserId))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.UserCurrentTaskList.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.UserCurrentTaskList.User.LastName));
        }
    }
}
