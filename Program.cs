using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Controller;
using Dsw2025Ej8.View;
namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controlador.Inicializar();
            Menu.Run();

        }
    }
}
