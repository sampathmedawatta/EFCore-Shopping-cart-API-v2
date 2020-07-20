using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Data.Data;
using System;

namespace OnlineShopping.Business.ManagerClasses
{
    public class ProductManager : BaseManager, IProductManager
    {


        public ProductManager(IOptions<AppSettings> appSetting, IMapper mapper) : base(appSetting, mapper)
        {
        }

        public OperationResult GetProducts()
        {
            ProductData.GetProducts();
            throw new NotImplementedException();
        }

        public OperationResult GetProductsByCategoryName(string Name)
        {
            ProductData.GetProductsByCategoryName(Name);
            return null;
        }

        public OperationResult GetProductsByOptions(string option)
        {
            ProductData.GetProductsByOptions(option);
            return null;
        }















        ///// <summary>
        ///// method get all products 
        ///// /// </summary>
        ///// <param name="id"> if if need to be filtered </param>
        ///// <returns></returns>

        //public OperationResult GetAllProducts(Guid? id)
        //{
        //    // new operation result object to hold response data
        //    OperationResult operationResult = new OperationResult();
        //    operationResult.Status = Enum.Status.Success;
        //    operationResult.Message = Constant.SuccessMessage;

        //    //check if id is available
        //    if (id == null)
        //    {
        //        var productList = ProductRepository.GetAll();
        //        operationResult.Data = _mapper.Map<IEnumerable<ProductReadDto>>(productList);
        //    }
        //    else
        //    {

        //        var product = ProductRepository.GetById((Guid)id);
        //        operationResult.Data = _mapper.Map<ProductReadDto>(product);
        //    }
        //    return operationResult;
        //}

        //public OperationResult GetProductsByOptions(string option)
        //{
        //    // new operation result object to hold response data
        //    OperationResult operationResult = new OperationResult();
        //    operationResult.Status = Enum.Status.Success;
        //    operationResult.Message = Constant.SuccessMessage;

        //    var productList = ProductRepository.GetAllByFilter(option);
        //    operationResult.Data = _mapper.Map<IEnumerable<ProductReadDto>>(productList);


        //    return operationResult;
        //}

        //public OperationResult GetProductsByCategoryName(string Name)
        //{
        //    // new operation result object to hold response data
        //    OperationResult operationResult = new OperationResult();
        //    operationResult.Status = Enum.Status.Success;
        //    operationResult.Message = Constant.SuccessMessage;

        //    var productList = ProductRepository.GetAllByCategoryName(Name);
        //    operationResult.Data = _mapper.Map<IEnumerable<ProductReadDto>>(productList);


        //    return operationResult;
        //}
    }
}
