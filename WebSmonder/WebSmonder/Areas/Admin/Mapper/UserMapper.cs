using AutoMapper;
using WebSmonder.Areas.Admin.Models.Users;
using WebSmonder.Data.Entities.Idenity;

namespace WebSmonder.Areas.Admin.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserEntity, UserItemViewModel>()
            .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Image))
            .ReverseMap();

    }
}
