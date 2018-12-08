using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Models.Order;

namespace WebStore.Domain.Dto.Order
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
