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
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCurrentTaskLists.FirstOrDefault().UserId))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.UserCurrentTaskLists.FirstOrDefault().User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.UserCurrentTaskLists.FirstOrDefault().User.LastName));
            CreateMap<CurrentTaskList, CurrentTaskListDto>()
                .ForMember(dest => dest.currentTaskDtos, opt => opt.MapFrom(src => src.CurrentTasks))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCurrentTaskLists.FirstOrDefault().UserId));
            CreateMap<CurrentTask, CurrentTaskDto>();
            CreateMap<User, UserDto>();
            CreateMap<CurrentTaskList, CurrentTaskListWithUsersDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UserCurrentTaskLists.Select(x=>x.User)));
        }
    }
}
