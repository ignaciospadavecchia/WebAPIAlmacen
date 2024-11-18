using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebAPIAlmacen.Models;
using WebAPIAlmacen.Services;
using WebAPIAlmacen.Services.Demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Esta configuraci�n evita que las consultas multitabla con Include generen errores de ciclos indefinidos
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Capturamos del app.settings la cadena de conexi�n a la base de datos
// Configuration.GetConnectionString va directamente a la propiedad ConnectionStrings y de ah� tomamos el valor de DefaultConnection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Nuestros servicios resolver�n dependencias de otras clases
// Registramos en el sistema de inyecci�n de dependencias de la aplicaci�n el ApplicationDbContext
builder.Services.AddDbContext<MiAlmacenContext>(options =>
            options.UseSqlServer(connectionString));

builder.Services.AddTransient<TransientService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<TestService>();
builder.Services.AddTransient<OperacionesService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<GestorArchivosService>();
builder.Services.AddSingleton<ContadorPeticionesService>();
builder.Services.AddHostedService<TareaProgramadaService>();

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

app.Run();
