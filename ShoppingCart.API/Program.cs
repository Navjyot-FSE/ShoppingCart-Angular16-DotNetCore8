//1. 
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models.EntityFramework;
using ShoppingCart.Repository;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options=>
	{
		options.AddPolicy("AllowAll",
			builder => 
			{
				builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}
		);
	}
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ShoppingCartConnectionstring = builder.Configuration.GetConnectionString("ShoppingCartConString");
builder.Services.AddDbContext<ShoppingCartDbContext>(db => 
        db.UseSqlServer(ShoppingCartConnectionstring), ServiceLifetime.Singleton);
builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();

//2.
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//3.
app.Run();