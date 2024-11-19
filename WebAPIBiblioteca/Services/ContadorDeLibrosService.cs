namespace WebAPIBiblioteca.Services
{
    public class ContadorDeLibrosService
    {
        int Contador = 0;

        public void Incrementar()
        {
            Contador++;
        }

        public int GetContadorDeLibros()
        {
            return Contador;
        }
    }
}
