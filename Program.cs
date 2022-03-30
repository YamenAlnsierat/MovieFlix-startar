using Microsoft.EntityFrameworkCore;
using movieflix_api.Data;

var builder = WebApplication.CreateBuilder(args);
//CORS Policy...
var reactApp = "_reactAppPolicy";

// Add services to the container.

// Add db context as a service..
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: reactApp, builder =>
  {
    builder.WithOrigins("*");
  });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(reactApp);

app.UseAuthorization();

app.MapControllers();

app.Run();
