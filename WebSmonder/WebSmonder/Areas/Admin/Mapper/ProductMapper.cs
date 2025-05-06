using AutoMapper;
using WebSmonder.Areas.Admin.Models.Product;
using WebSmonder.Data.Entities;

namespace WebSmonder.Areas.Admin.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductEntity, ProductItemViewModel>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(x => x.Images, opt => opt.MapFrom(x => x.ProductImages.Select(x => x.Name)));

        CreateMap<CreateProductViewModel, ProductEntity>()
            .ForMember(x => x.ProductImages, opt => opt.Ignore())
            .ForMember(x => x.CategoryId, opt => opt.Ignore());

    }
}
