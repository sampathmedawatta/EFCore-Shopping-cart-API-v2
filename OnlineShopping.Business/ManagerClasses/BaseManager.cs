﻿using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces.ManagerClasses;
using OnlineShopping.Common;
using OnlineShopping.Data.Data;

namespace OnlineShopping.Business.ManagerClasses
{
    public class BaseManager : IBaseManager
    {
        #region Private Properties

        private ProductData productData;
        private CategoryData categoryData;
        private UserData userData;

        private readonly string ConnectionString;
        private IMapper _mapper { get; }

        public BaseManager(IOptions<AppSettings> appSetting, IMapper mapper)
        {
            AppSettings configSettings = appSetting.Value;
            ConnectionString = configSettings.ConnectionString;
            _mapper = mapper;
        }
        #endregion
        #region Public Properties

        /// <summary>
        /// Product Data Public Property
        /// </summary>
        public ProductData ProductData
        {
            get
            {
                productData = productData ?? new ProductData(ConnectionString, _mapper);
                return productData;
            }
        }

        /// <summary>
        /// Category Data Public Property
        /// </summary>
        public CategoryData CategoryData
        {
            get
            {
                categoryData = categoryData ?? new CategoryData(ConnectionString, _mapper);
                return categoryData;
            }
        }

        /// <summary>
        /// User Data Public Property
        /// </summary>
        public UserData UserData
        {
            get
            {
                userData = userData ?? new UserData(ConnectionString, _mapper);
                return userData;
            }
        }
        #endregion
    }
}
