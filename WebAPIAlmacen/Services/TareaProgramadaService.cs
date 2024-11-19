
using Microsoft.EntityFrameworkCore;
using WebAPIAlmacen.Models;

namespace WebAPIAlmacen.Services
{
    public class TareaProgramadaService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IWebHostEnvironment env;
        private readonly string nombreArchivo = "Archivo.txt";
        private Timer timer;

        public TareaProgramadaService(IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            this.serviceProvider = serviceProvider;
            this.env = env;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(EscribirDatos, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
<<<<<<< HEAD
            Escribir("Proceso iniciado a las: " + DateTime.Now);
=======
            Escribir("Proceso iniciado");
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
<<<<<<< HEAD
            Escribir("Proceso finalizado a las: " + DateTime.Now);
=======
            Escribir("Proceso finalizado a las " + DateTime.Now);
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
            return Task.CompletedTask; // Parar la depuración desde el icono de IIS para que se ejecute el StopAsync
        }

        private async void EscribirDatos(object state)
        {
<<<<<<< HEAD
            using (var scope = serviceProvider.CreateScope()) // Necesitamos delimitar un alcance scoped. Los servicios IHostedService son singleton y el ApplicationDBContext Scoped. A continuación "abrimos" un scoped con using para poder
       //         utilizar el ApplicationDbContext en este servicio Singleton
=======
            using (var scope = serviceProvider.CreateScope()) // Necesitamos delimitar un alcance scoped. Los servicios IHostedService son singleton y el ApplicationDBContext Scoped. A continuación "abrimos" un scoped con using para poder utilizar el ApplicationDbContext en este servicio Singleton
>>>>>>> 65241861d8a4d94baece835ef37c9cf4ddd2a059
            {
                var context = scope.ServiceProvider.GetRequiredService<MiAlmacenContext>();
                var primerProducto = await context.Productos.Select(x => x.Nombre).FirstAsync();
                Escribir(primerProducto);
            }
        }
        private void Escribir(string mensaje)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombreArchivo}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true))
            {
                writer.WriteLine(mensaje);
            }
        }
    }

}
