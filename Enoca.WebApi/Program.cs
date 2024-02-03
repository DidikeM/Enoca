using Enoca.Business.Abstract;
using Enoca.Business.Concrete;
using Enoca.DataAccess.Abstract;
using Enoca.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContextFactory<EnocaCarrierContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddSingleton<ICarrierService, CarrierService>();
builder.Services.AddSingleton<ICarrierConfigurationService, CarrierConfigurationService>();
builder.Services.AddSingleton<IOrderService, OrderService>();

builder.Services.AddSingleton<ICarrierDal, EfCarrierDal>();
builder.Services.AddSingleton<ICarrierConfigurationDal, EfCarrierConfigurationDal>();
builder.Services.AddSingleton<IOrderDal, EfOrderDal>();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<EnocaCarrierContext>();
    context.Database.Migrate();
}

app.Run();
