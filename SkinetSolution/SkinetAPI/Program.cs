using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer("name=ConnectionToMySQL"));


//Adding the interface and its implemented class as a service = repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//
builder.Services.AddScoped(typeof (IGenericRepository<>), typeof (GenericRepository<>));

//Adding Automapper as service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

//
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync(); //Applies any pending migrations for the database context, or
                                           //creates the database if it does not exist. This method ensures that the
                                           //database schema is up-to-date with the model defined by the app.

    await StoreContextSeed.SeedAsync(context);
}
catch (Exception e)
{
    logger.LogError(e, "An error occured during migrations");
}

app.Run();
