using AutoMapper;
using WebSmonder.Data.Entities.Idenity;
using WebSmonder.Models.Account;
namespace WebSmonder.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserEntity, UserLinkViewModel>()
            .ForMember(x => x.Name, opt =>
                opt.MapFrom(x => $"{x.LastName} {x.FirstName}"))
            .ForMember(x => x.Image, opt =>
                opt.MapFrom(x => x.Image ?? "default.webp"));

        CreateMap<RegisterViewModel, UserEntity>()
            .ForMember(x => x.Image, opt => opt.Ignore())
            .ForMember(x => x.UserName, opt => opt.MapFrom(x=>x.Email));
    }
}
