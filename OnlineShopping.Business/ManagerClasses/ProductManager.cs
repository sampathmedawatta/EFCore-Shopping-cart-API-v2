using AutoMapper;
using OnlineShopping.Common;
using OnlineShopping.Data.Data;
using OnlineShopping.Entity.Models.Product;
using System;
using System.Collections.Generic;

namespace OnlineShopping.Business.ManagerClasses
{
    public class ProductManager
    {
        private readonly ApplicationConfiguration _applicationConfiguration;

        public IMapper _mapper { get; }

        private ProductData productData;
        public ProductData ProductData
        {
            get
            {
                productData = productData ?? new ProductData(_applicationConfiguration, _mapper);
                return productData;
            }
        }

        public ProductManager(ApplicationConfiguration applicationConfiguration, IMapper mapper)
        {
            _applicationConfiguration = applicationConfiguration;
            _mapper = mapper;
        }

        public IEnumerable<ProductReadDto> GetProducts()
        {
            return ProductData.GetProducts();
        }

        public ProductReadDto GetProductById(Guid id)
        {
            return ProductData.GetById(id);
        }

        public IEnumerable<ProductReadDto> GetProductsByOptions(string option)
        {
            return ProductData.GetProductsByOptions(option);
        }

        public IEnumerable<ProductReadDto> GetProductsByCategoryName(string Name)
        {
            return ProductData.GetProductsByCategoryName(Name);
        }
    }
}
