using AutoMapper;
using OnlineShopping.Entity.Models.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Data
{
    public class ProductData : BaseData
    {
        private readonly IMapper _mapper;
        public ProductData(string applicationConfiguration, IMapper mapper) : base(applicationConfiguration)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsAsunc()
        {
            var productList = await ProductRepository.GetAllAsunc();
            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);

        }

        public async Task<ProductReadDto> GetByIdAsunc(Guid id)
        {
            // TODO handle the common error in the middleware 

            var product = await ProductRepository.GetByIdAsunc(id);
            return _mapper.Map<ProductReadDto>(product);
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByOptionsAsunc(string option)
        {
            // TODO handle the common error in the middleware 
            var productList = await ProductRepository.GetAllByFilterAsunc(option);
            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoryNameAsunc(string Name)
        {
            // TODO handle the common error in the middleware 
            var productList = await ProductRepository.GetAllByCategoryNameAsunc(Name);
            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);
        }
    }
}
