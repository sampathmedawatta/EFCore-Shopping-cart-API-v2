using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class OrderRepository : IOrderRepository<OrderDto>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<OrderEntry> table;
        private readonly IMapper _mapper;

        public OrderRepository(OnlineShoppingContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<OrderEntry>();
            _mapper = mapper;
        }

        public async Task<int> Insert(OrderDto entity)
        {
            OrderEntry orderEntry;
            orderEntry = _mapper.Map<OrderDto, OrderEntry>(entity);

            this.context.Set<OrderEntry>().Add(orderEntry);
            int excecutedRows = await this.context.SaveChangesAsync();

            entity.Id = orderEntry.Id;

            return excecutedRows;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }



        public void Update(OrderDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
