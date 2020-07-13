using AutoMapper;
using OnlineShopping.Common;
using OnlineShopping.Common.Models.Category;
using System;
using System.Collections.Generic;
using Enum = OnlineShopping.Common.Enum;

namespace OnlineShopping.Business.ManagerClasses
{
    public class CategoryManager : BaseManager
    {
        private readonly IMapper _mapper;

        public CategoryManager(ApplicationConfiguration applicationConfiguration, IMapper mapper) : base(applicationConfiguration)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// method get all products 
        /// /// </summary>
        /// <param name="id"> if if need to be filtered </param>
        /// <returns></returns>

        public OperationResult GetAllCategories(Guid? id)
        {
            // new operation result object to hold response data
            OperationResult operationResult = new OperationResult();
            operationResult.Status = Enum.Status.Success;
            operationResult.Message = Constant.SuccessMessage;

            //check if id is available
            if (id == null)
            {
                var productList = CategoryRepository.GetAll();
                operationResult.Data = _mapper.Map<IEnumerable<CategoryReadDto>>(productList);
            }
            else
            {

                var product = CategoryRepository.GetById((Guid)id);
                operationResult.Data = _mapper.Map<CategoryReadDto>(product);
            }
            return operationResult;
        }

    }
}
