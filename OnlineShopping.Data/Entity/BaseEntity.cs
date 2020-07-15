using System;

namespace OnlineShopping.Data.Entity
{
    public class BaseEntity : IBaseEntity
    {
        // implement common operations
        public Guid Id { get; set; }


    }
}
