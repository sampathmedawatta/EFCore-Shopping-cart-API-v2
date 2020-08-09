using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await table
                .Include(I => I.OrderItemEntries)
                .Include(p => p.PaymentMethod)
                .Include(s => s.OrderStatus)
                .Where(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();

            return _mapper.Map<OrderEntry, OrderDto>(order);
        }


        public async Task<int> Insert(OrderDto entity)
        {
            OrderEntry orderEntry;
            orderEntry = _mapper.Map<OrderDto, OrderEntry>(entity);

            //TODO set payment method and order status
            //orderEntry.PaymentMethodId = Guid.Parse("5771e231-bace-44cb-80e2-2db0802cb29f");
            orderEntry.OrderStatusId = Guid.Parse("d03cce15-f001-4a41-a4e1-367876d58437");
            orderEntry.OrderDate = DateTime.Now;
            orderEntry.DiscountTotal = 0;


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




        public void Update(OrderDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
