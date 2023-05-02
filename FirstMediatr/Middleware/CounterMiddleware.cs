using FirstMediatr.Data.Service;
using Microsoft.AspNetCore.Http.Extensions;

namespace FirstMediatr.Middleware
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;
        private int _i = 0;

        public CounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IDummyBookService dummyBookService) 
        {
            if (_i == int.MaxValue)
            {
                _i = 0;
            }
            dummyBookService.Count = _i++;

            if (context.Request.GetDisplayUrl().Contains("count"))
            {
                await context.Response.WriteAsync(_i.ToString());
            }
            await _next(context);
        }

    }
}
