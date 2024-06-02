using Serilog;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DvdRental.Library;
using DvdRental.Library.Extensions;
using DvdRental.Api.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Initialize logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddHandlers();
builder.Services.AddFactories();
builder.Services.AddValidators();
builder.Services.AddCalculators();
builder.Services.AddRepositories();
builder.Services.AddWebServices(builder.Configuration);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

var config = builder.Configuration;
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
             builder =>
             {
                 builder
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .WithOrigins(config.GetSection("CorsOrigins").Get<string[]>())
                .AllowCredentials();
             });
});

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// initialize database customer defined type mapping
CommonUtils.InitializeDbHandlers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<LogUserNameMiddleware>();
app.MapControllers();

app.Run();



