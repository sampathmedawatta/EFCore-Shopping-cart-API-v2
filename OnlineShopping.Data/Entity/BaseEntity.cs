using System;

namespace OnlineShopping.Data.Entity
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        // implement common operations
    }
}
