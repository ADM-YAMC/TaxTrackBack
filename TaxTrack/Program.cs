using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Repository;
using ServicesLayer.ContribuyentesFiscalesServices;
using ServicesLayer.ErrosServices;
using ServicesLayer.TipoContibuyenteServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaxTrackContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaxTrackDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IContribuyentesFiscalesService, ContribuyentesFiscalesService>();
builder.Services.AddScoped<IErrosService, ErrosService>();
builder.Services.AddScoped<ITipoContibuyenteService, TipoContibuyenteService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(builder =>
{
    builder.SetIsOriginAllowed(origin => true)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});

app.MapControllers();

app.Run();
