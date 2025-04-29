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
    }
}
