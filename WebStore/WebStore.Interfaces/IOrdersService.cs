using System.Collections.Generic;
using WebStore.Domain.Dto.Order;

namespace WebStore.Infrastuctures.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDto> GetUserOrders(string userName);

        OrderDto GetOrderById(int id);

        OrderDto CreateOrder(CreateOrderModel orderModel, string userName);
    }
}
