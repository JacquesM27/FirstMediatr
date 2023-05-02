using FirstMediatr.Data.Service;
using FirstMediatr.Middleware;

namespace FirstMediatr.Configuration
{
    public static class CustomConfiguration
    {

        public static IApplicationBuilder RegisterCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<FirstMiddleware>();
        }

        public static IApplicationBuilder RegisterCounterMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CounterMiddleware>();
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services.AddSingleton<IDummyBookService, DummyBookService>();
        }

        public static IApplicationBuilder RegisterExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RestApiExceptionHandlingMiddleware>();
        }
    }
}
