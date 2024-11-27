using Microsoft.AspNetCore.HttpOverrides;
using VirtLab.Extensions;
using NLog;
using Microsoft.Extensions.DependencyInjection;
using Contracts;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

LogFactory logFactory =
    LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "VirtLab API",
        Version = "v1",
        Description = "API documentation for the VirtLab project",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com")
        }
    });
});

builder.Services.AddControllers().AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        opt.JsonSerializerOptions.WriteIndented = true;

    })
    .AddApplicationPart(typeof(VirtLab.Presentation.AssemblyReference).Assembly);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "VirtLab API v1");
    options.RoutePrefix = string.Empty; // Swagger буде доступний за кореневим URL
});


var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
