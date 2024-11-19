using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
<<<<<<< HEAD
using WebAPIBiblioteca.Filters;
using WebAPIBiblioteca.Middlewares;
using WebAPIBiblioteca.Models;
using WebAPIBiblioteca.Services;
=======
using WebAPIBiblioteca.Models;
using WebAPIBiblioteca.Services;
using static WebAPIAlmacen.Controllers.ProductosController;
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

<<<<<<< HEAD
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FiltroDeExcepcion));

}).AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

=======
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MiBibliotecaContext>(options =>
            options.UseSqlServer(connectionString));

builder.Services.AddTransient<OperacionesService>();
builder.Services.AddTransient<GestorArchivosService>();
<<<<<<< HEAD
// builder.Services.AddHostedService<TareaProgramadaService>();
=======
builder.Services.AddSingleton<ContadorPeticionesService>();
builder.Services.AddSingleton<ContadorDeLibrosService>();
builder.Services.AddHostedService<TareaProgramadaService>();

>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
<<<<<<< HEAD
app.UseMiddleware<LogMiddleware>();
=======

>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
app.UseAuthorization();

app.MapControllers();

app.Run();
