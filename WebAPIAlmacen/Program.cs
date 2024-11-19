using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Serilog;
using System.Text.Json.Serialization;
using WebAPIAlmacen.Middlewares;
=======
using System.Text.Json.Serialization;
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
using WebAPIAlmacen.Models;
using WebAPIAlmacen.Services;
using WebAPIAlmacen.Services.Demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Esta configuración evita que las consultas multitabla con Include generen errores de ciclos indefinidos
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Capturamos del app.settings la cadena de conexión a la base de datos
// Configuration.GetConnectionString va directamente a la propiedad ConnectionStrings y de ahí tomamos el valor de DefaultConnection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Nuestros servicios resolverán dependencias de otras clases
// Registramos en el sistema de inyección de dependencias de la aplicación el ApplicationDbContext
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
<<<<<<< HEAD
//builder.Services.AddHostedService<TareaProgramadaService>();


// Serilog
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        // builder.WithOrigins("https://www.xxxxxxxxxxx.com").AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
=======
builder.Services.AddHostedService<TareaProgramadaService>();
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
<<<<<<< HEAD
app.UseCors();
app.UseMiddleware<LogMiddleware>();
=======
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
