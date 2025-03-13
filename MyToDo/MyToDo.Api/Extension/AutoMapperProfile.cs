using AutoMapper;
using AutoMapper.Configuration;
using MyToDo.Api.Context;
using MyToDo.Shared.Dtos;

namespace MyToDo.Api.Extension {
    /// <summary>
    /// AutoMapper配置文件 配置映射关系
    /// </summary>
    public class AutoMapperProfile : Profile {

        public AutoMapperProfile() {
            CreateMap<ToDo, ToDoDto>().ReverseMap(); //ToDo和ToDoDto双向映射
            CreateMap<Memo, MemoDto>().ReverseMap(); //ToDo和ToDoDto双向映射
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
