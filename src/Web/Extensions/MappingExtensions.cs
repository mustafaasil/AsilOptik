using Web.Models;

namespace Web.Extensions
{
    public static class MappingExtensions
    {
        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            return new BasketViewModel()
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
                Items = basket.Items.Select(x => new BasketItemViewModel()
                {
                    Id = x.Id,
                    PictureUri = x.Product.PictureUri,
                    Quantity = x.Quantity,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    UnitPrice = x.Product.Price
                }).ToList()
            };
        }
    }
}
