using FirstMediatr.Middleware;

namespace FirstMediatr.Configuration
{
    public static class CustomMiddlewares
    {

        public static IApplicationBuilder RegisterCustomMiddlewares(this IApplicationBuilder app)
        {
            return app.UseMiddleware<FirstMiddleware>();
        }
    }
}
