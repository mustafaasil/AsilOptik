﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketServices
    {
        Task<Basket> GetOrCreatBasketAsync(string buyerId);
        Task<Basket> AddItemToBasketAsync(string buyerId, int productId, int quantity);
        Task EmptyBasketAsync(string buyerId);
        Task DeleteBasketItemAsync(string buyerId, int productId);
        Task<Basket> SetQuantities(string buyerId, Dictionary<int, int> quantities);
        Task TransferBasketAsync(string buyerId, string destinationBuyerId);
        
    }
}
