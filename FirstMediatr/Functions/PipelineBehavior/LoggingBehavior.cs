﻿using MediatR;

namespace FirstMediatr.Functions.PipelineBehavior
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Logger: Handling request:{typeof(TRequest).Name}");
            var response = await next();
            _logger.LogInformation($"Logger: Handled response:{typeof(TResponse).Name}");
            return response;
        }
    }
}
