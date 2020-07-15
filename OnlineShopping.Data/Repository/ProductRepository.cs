﻿using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.Data.Repository
{
    public class ProductRepository : IRepository<ProductEntiry>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<ProductEntiry> table;
        public ProductRepository(OnlineShoppingContext context)
        {
            this.context = context;
            table = context.Set<ProductEntiry>();
        }

        /// <summary>
        ///  retrun active product list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductEntiry> GetAll()
        {
            return table
                .Include(c => c.Category)
                .Include(u => u.UnitType)
                .Include(p => p.Picture)
                .Where(p => p.IsActive.Equals(true)).ToList();
        }

        /// <summary>
        /// return product list by option 
        /// </summary>
        /// <param name="FilterBy"></param>
        /// <returns></returns>
        public IEnumerable<ProductEntiry> GetAllByFilter(string FilterBy)
        {

            if (FilterBy.Equals("FeatureProducts"))
            {
                return table
                  .Include(c => c.Category)
                  .Include(u => u.UnitType)
                  .Include(p => p.Picture)
                  .Where(p => p.IsActive.Equals(true))
                  .Where(p => p.IsFeatureProduct.Equals(true))
                  .ToList();
            }
            else if (FilterBy.Equals("HomePageProducts"))
            {
                return table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(p => p.ShowInHomePage.Equals(true))
               .Where(p => p.IsActive.Equals(true)).ToList();
            }

            return null;
        }

        /// <summary>
        /// return product list by category name
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public IEnumerable<ProductEntiry> GetAllByCategoryName(string CategoryName)
        {

            return table
               .Include(c => c.Category)
               .Include(u => u.UnitType)
               .Include(p => p.Picture)
               .Where(ct => ct.Category.Name.Equals(CategoryName))
               .Where(p => p.IsActive.Equals(true)).ToList();
        }


        public ProductEntiry GetById(Guid id)
        {
            return table.Find(id);
        }

        public void Insert(ProductEntiry entity)
        {
            table.Add(entity);
        }

        public void Update(ProductEntiry entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            ProductEntiry existing = table.Find(id);
            table.Remove(existing);
        }

    }
}
