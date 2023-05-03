using FirstMediatr.Configuration;
using FirstMediatr.Functions.PipelineBehavior;
using MediatR;
using System.Reflection;
using NLog;
using NLog.Web;
using FluentValidation.AspNetCore;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
    builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(LoggingBehavior<,>));

    builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ConsoleWriteLineBehavior<,>));

    builder.Services.RegisterServices();

    //builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    builder.Services.AddControllers()
                    .AddFluentValidation(options =>
                    {
                        // Validate child properties and root collection elements
                        options.ImplicitlyValidateChildProperties = true;
                        options.ImplicitlyValidateRootCollectionElements = true;

                        // Automatic registration of validators in assembly
                        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.RegisterCustomMiddleware();
    app.RegisterCounterMiddleware();
    app.RegisterExceptionHandlerMiddleware();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}