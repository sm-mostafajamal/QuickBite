using QuickBite.API;
using QuickBite.Application;
using QuickBite.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/api/error");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
