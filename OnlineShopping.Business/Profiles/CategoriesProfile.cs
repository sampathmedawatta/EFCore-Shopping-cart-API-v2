using AutoMapper;
using OnlineShopping.Common.Models.Category;
using OnlineShopping.Data.Entity;

namespace OnlineShopping.Business.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoryEntity, CategoryReadDto>();

        }
    }
}
