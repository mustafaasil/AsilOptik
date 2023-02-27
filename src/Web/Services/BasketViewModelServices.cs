using System.Security.Claims;
using Web.Extensions;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class BasketViewModelServices : IBasketViewModelService
    {
        private readonly IBasketServices _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketViewModelServices(IBasketServices basketService, IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpContext HttpContext => _httpContextAccessor.HttpContext!;
        public string? UserId => HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string? AnonId => _createdAnonId ?? HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];
        public string BuyerId => UserId ?? AnonId ?? CreateAnonymousId();

        private string? _createdAnonId;

        private string CreateAnonymousId()
        {
            _createdAnonId = Guid.NewGuid().ToString();

            HttpContext.Response.Cookies.Append(Constants.BASKET_COOKIENAME, _createdAnonId,
                new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(2),
                    IsEssential = true
                });

            return _createdAnonId;
        }

        public async Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity)
        {
            var basket = await _basketService.AddItemToBasketAsync(BuyerId, productId, quantity);

            return basket.ToBasketViewModel();


        }

        public async Task<BasketViewModel> GetBasketViewModelAsync()
        {
            var basket = await _basketService.GetOrCreatBasketAsync(BuyerId);
            return basket.ToBasketViewModel();
        }

        public async Task EmptyBasketAsync()
        {
            await _basketService.EmptyBasketAsync(BuyerId);
        }

        public async Task DeleteBasketItemAsync(int productId)
        {
            await _basketService.DeleteBasketItemAsync(BuyerId,productId);
        }

        public async Task UpdateBasketAsync(Dictionary<int, int> quantities)
        {
            await _basketService.SetQuantities(BuyerId, quantities);
        }

        public async Task TransferBasketIfNecessary()
        {
            if (UserId != null && AnonId != null)
            {
                await _basketService.TransferBasketAsync(AnonId, UserId);
            }
        }
    }
}
