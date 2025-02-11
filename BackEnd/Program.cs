using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Serilog
builder.Logging.ClearProviders();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Error()
);
#endregion

#region DI
builder.Services.AddDbContext<NorthwndContext>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

// Registro de servicios y DAL para Category
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();

// Registro de servicios y DAL para Shipper
builder.Services.AddScoped<IShipperService, ShipperService>();
builder.Services.AddScoped<IShipperDAL, ShipperDAL>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
