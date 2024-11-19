using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebAPIBiblioteca.Filters;
using WebAPIBiblioteca.Middlewares;
using WebAPIBiblioteca.Models;
using WebAPIBiblioteca.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FiltroDeExcepcion));

}).AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MiBibliotecaContext>(options =>
            options.UseSqlServer(connectionString));

builder.Services.AddTransient<OperacionesService>();
builder.Services.AddTransient<GestorArchivosService>();
// builder.Services.AddHostedService<TareaProgramadaService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<LogMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
