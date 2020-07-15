using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping.Data.Repository
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<CategoryEntity> table;
        public CategoryRepository(OnlineShoppingContext context)
        {
            this.context = context;
            table = context.Set<CategoryEntity>();
        }

        /// <summary>
        /// return active category list 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryEntity> GetAll()
        {
            return table.Where(p => p.IsActive.Equals(true)).ToList();
        }


        public CategoryEntity GetById(Guid id)
        {
            return table.Find(id);
        }

        public void Insert(CategoryEntity entity)
        {
            table.Add(entity);
        }

        public void Update(CategoryEntity entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(Guid id)
        {
            CategoryEntity existing = table.Find(id);
            table.Remove(existing);
        }
    }
}
