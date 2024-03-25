using ExchangeRatesAssignment.Api.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateBootstrapLogger();

Log.Information("Starting up");

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
    //builder.Logging.ClearProviders();
    //builder.Logging.AddSerilog(logger);
    builder.Host.UseSerilog(logger);

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //add services to DI container
    {
        var services = builder.Services;
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        services.AddSingleton<IPartnerRateService, FilePartnerRateService>();
        services.AddScoped<IExchangeRateService, ExchangeRateService>();
    }

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}



