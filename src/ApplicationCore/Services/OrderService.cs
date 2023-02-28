using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketServices _basketServices;
        private readonly IRepository<Order> _orderRepo;

        public OrderService(IBasketServices basketServices, IRepository<Order> orderRepo)
        {
            _basketServices = basketServices;
            _orderRepo = orderRepo;
        }

        public async Task CreateOrderAsync(string buyerId, Address shippingAddress)
        {
            var basket = await _basketServices.GetOrCreatBasketAsync(buyerId);

            Order order = new Order() 
            {
                ShippingAddress=shippingAddress,
                BuyerId=buyerId,
                Items= basket.Items.Select(x => new OrderItem()
                {
                    ProductId=x.ProductId,
                    ProductName= x.Product.Name,
                    Quantity=x.Quantity,
                    UnitPrice= x.Product.Price,
                    PictureUri=x.Product.PictureUri,

                }).ToList()
            };

            await _orderRepo.AddAsync(order);
        }
    }
}
