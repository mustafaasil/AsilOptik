using Web.Interfaces;

namespace Web.Middlewears
{
    public class TransferBasketMiddleware 
    {
        private readonly RequestDelegate _next;

        public TransferBasketMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IBasketViewModelService basketViewModelService)
        {
            // basketviewmodelservicese sepetleri eger gerekiyorsa taşı metodu yaz çagır

            await basketViewModelService.TransferBasketIfNecessary();


            await _next(context);
        }
    }
}
