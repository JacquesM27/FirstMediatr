using MediatR;

namespace FirstMediatr.Functions.PipelineBehavior
{
    public class ConsoleWriteLineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public ConsoleWriteLineBehavior()
        {

        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Handling request:{typeof(TRequest).Name}");

            var response = await next();

            Console.WriteLine($"Handled request:{typeof(TResponse).Name}");

            return response;
        }
    }
}
