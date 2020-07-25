using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShopping.API.Controllers;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Entity.Models.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.UnitTest.API
{
    [TestClass]
    public class CategoryControllerUnitTest
    {

        private Mock<ICategoryManager> _categoryManager;
        private Mock<ILogger<CategoryController>> _logger;
        private CategoryController _controller;

        [TestInitialize]
        public void CategoryController()
        {
            _categoryManager = new Mock<ICategoryManager>();
            _logger = new Mock<ILogger<CategoryController>>();
            _categoryManager.Setup(x => x.GetCategoriesAsunc()).ReturnsAsync(() =>
            {
                return new OperationResult
                {
                    Data = new List<CategoryDto>()
                    {
                        new CategoryDto
                        {

                            Id = Guid.NewGuid(),
                            Name = "Computers",
                            Description = "all computers"
                        },
                        new CategoryDto
                        {

                            Id = Guid.NewGuid(),
                            Name = "Electronics",
                            Description = "all Electronics"
                        }
                         ,
                        new CategoryDto
                        {

                            Id = Guid.NewGuid(),
                            Name = "Accessories",
                            Description = "all Accessories"
                        },
                        new CategoryDto
                        {

                            Id = Guid.NewGuid(),
                            Name = "Cameras",
                            Description = "all Cameras"
                        }
                    },
                    StatusId = 200,
                    Status = Enums.Status.Success,
                    Message = Constant.SuccessMessage,
                    Error = string.Empty
                };


            });

        }




        [TestMethod]

        public async Task GetAsunc_WhenSuccessfullRequest_Return200OkWithOperationResult()
        {
            //Arrange
            _controller = new CategoryController(_categoryManager.Object, _logger.Object);

            //Act
            dynamic result = await _controller.GetAsunc();

            //Assert
            Assert.AreEqual(200, result.Result.Value.StatusId);

        }

        [TestMethod]

        public async Task GetAsunc_WhenDataNotFound_Return400BadRequestOptionResult()
        {
            //Arrange
            _categoryManager.Setup(x => x.GetCategoriesAsunc()).ReturnsAsync(() =>
            {
                return new OperationResult
                {
                    Data = null,
                    StatusId = 400,
                    Status = Enums.Status.Error,
                    Message = Constant.FailMessage,
                    Error = "No Records Found"
                };
            });

            _controller = new CategoryController(_categoryManager.Object, _logger.Object);

            //Act
            dynamic result = await _controller.GetAsunc();

            //Assert
            Assert.AreEqual(400, result.Result.Value.StatusId);

        }
    }
}
