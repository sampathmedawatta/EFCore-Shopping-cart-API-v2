using OnlineShopping.Entity.Models.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OnlineShopping.Entity.Models.Order
{
    public class OrderDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("paymentMethodId")]
        public Guid PaymentMethodId { get; set; }

        [JsonPropertyName("paymentMethod")]
        public PaymentMethodDto PaymentMethod { get; set; }

        [JsonPropertyName("totalAmount")]
        public double TotalAmount { get; set; }
        [JsonPropertyName("tax")]
        public double Tax { get; set; }
        [JsonPropertyName("subTotal")]
        public double SubTotal { get; set; }
        [JsonPropertyName("deliveryDetails")]
        public DeliveryDetailsDto DeliveryDetails { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemDto> OrderItems { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }


    }
}
