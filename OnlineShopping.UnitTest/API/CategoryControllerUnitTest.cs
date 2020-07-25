using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShopping.API.Controllers;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models.Category;
using System;
using System.Collections.Generic;

namespace OnlineShopping.UnitTest.API
{
    [TestClass]
    public class CategoryControllerUnitTest
    {

        private readonly Mock<ICategoryManager> _categoryManager;
        private readonly Mock<ILogger<CategoryController>> _logger;

        private CategoryController _controller;
        [TestInitialize]
        public void CategoryController()
        {
            _categoryManager.Setup(x => x.GetCategoriesAsunc()).ReturnsAsync(new OperationResult
            {
                Data = new List<CategoryDto>() {
                    new CategoryDto {

                        Id = Guid.NewGuid() ,
                        Name = "Computers",
                        Description = "all computers"
                    },
                     new CategoryDto {

                        Id = Guid.NewGuid() ,
                        Name = "Electronics",
                        Description = "all Electronics"
                    }
                     ,
                     new CategoryDto {

                        Id = Guid.NewGuid() ,
                        Name = "Accessories",
                        Description = "all Accessories"
                    },
                     new CategoryDto {

                        Id = Guid.NewGuid() ,
                        Name = "Cameras",
                        Description = "all Cameras"
                    }
                },
                StatusId = 200,
                Status = Enums.Status.Success,
                Message = Constant.SuccessMessage,
                Error = null
            });

        }


        [TestMethod]

        public async void GetAsunc_WhenSuccessfullRequest_Return200OkWithOperationResult()
        {
            //Arrange
            _controller = new CategoryController(_categoryManager.Object, _logger.Object);

            //Act
            ActionResult<OperationResult> result = await _controller.GetAsunc();

            //Assert
            //Assert.AreEqual(HttpStatusCode.OK, result.Value.StatusId);

            Assert.IsNotNull(result);
        }
    }
}
