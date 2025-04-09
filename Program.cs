using Microsoft.Extensions.Configuration;
using webApiTaxi;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add repositories and services
builder.Services.AddTransient<IOrderRepository, OrdersRepository>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IBrand_carsRepository, Brand_carsRepository>();
builder.Services.AddTransient<IBrand_carsService, Brand_carsService>();
builder.Services.AddTransient<IColor_carsRepository, Color_carsRepository>();
builder.Services.AddTransient<IColor_carsService, Color_carsService>();
builder.Services.AddTransient<ICarsRepository, CarsRepository>();
builder.Services.AddTransient<ICarsService, CarsService>();
builder.Services.AddTransient<IDriversRepository, DriversRepository>();
builder.Services.AddTransient<IDriversService, DriversService>();
builder.Services.AddTransient<ILicenseRepository, LicenseRepository>();
builder.Services.AddTransient<ILicenseService, LicenseService>();
builder.Services.AddTransient<IRateRepository, RateRepository>();
builder.Services.AddTransient<IRateService, RateService>();
builder.Services.AddTransient<IStatusesRepository, StatusesRepository>();
builder.Services.AddTransient<IStatusesService, StatusesService>();
builder.Services.AddTransient<ITypes_tripRepository, Types_tripRepository>();
builder.Services.AddTransient<ITypes_tripService, Types_tripService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();

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

app.Run();
