using AutoMapper;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.Category;

namespace OnlineShopping.Data.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>();

        }
    }
}
