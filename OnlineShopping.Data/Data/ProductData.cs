using AutoMapper;
using OnlineShopping.Common;
using OnlineShopping.Data.Repository;
using OnlineShopping.Entity.Models.Product;
using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Data
{
    public class ProductData : BaseData
    {
        private readonly IMapper _mapper;
        public ProductData(ApplicationConfiguration applicationConfiguration, IMapper mapper) : base(applicationConfiguration)
        {
            _mapper = mapper;
        }

        public IEnumerable<ProductReadDto> GetProducts()
        {
            // TODO handle the common error in the middleware 

            var productList = ProductRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);

        }

        public ProductReadDto GetById(Guid id)
        {
            // TODO handle the common error in the middleware 

            var product = ProductRepository.GetById(id);
            return _mapper.Map<ProductReadDto>(product);
        }

        public IEnumerable<ProductReadDto> GetProductsByOptions(string option)
        {
            // TODO handle the common error in the middleware 
            var productList = ProductRepository.GetAllByFilter(option);
            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);
        }

        public IEnumerable<ProductReadDto> GetProductsByCategoryName(string Name)
        {
            // TODO handle the common error in the middleware 
            var productList = ProductRepository.GetAllByCategoryName(Name);
            return _mapper.Map<IEnumerable<ProductReadDto>>(productList);
        }
    }
}
