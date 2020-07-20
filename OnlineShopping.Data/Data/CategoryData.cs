using AutoMapper;
using OnlineShopping.Entity.Models.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Data
{
    public class CategoryData : BaseData
    {
        private readonly IMapper _mapper;
        public CategoryData(string applicationConfiguration, IMapper mapper) : base(applicationConfiguration)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryReadDto>> GetCategoriesAsunc()
        {
            var productList = await CategoryRepository.GetAllAsunc();
            return _mapper.Map<IEnumerable<CategoryReadDto>>(productList);

        }
    }
}
