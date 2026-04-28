using QuickBite.Application;
using QuickBite.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/api/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
