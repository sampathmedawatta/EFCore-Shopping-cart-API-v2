using AutoMapper;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.Product;

namespace OnlineShopping.Data.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductEntiry, ProductReadDto>()
                .ForMember(dest =>
                dest.Price,
                opt => opt.MapFrom(src => src.SellingPrice))
                .ForMember(dest =>
                dest.ImageUrl,
                opt => opt.MapFrom(src => src.Picture.FilePath))
                ;
        }

    }
}
