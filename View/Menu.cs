using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Controller;
using Microsoft.VisualBasic.FileIO;

namespace Dsw2025Ej8.View
{
    internal static class Menu
    {
        public static void Run()
        {
            int option = 1;
            do
            {
                Console.WriteLine("Bienvenido al sistema de cuentas bancarias");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Realizar un Deposito");
                Console.WriteLine("2. Realizar un Retiro");
                Console.WriteLine("3. Consultar saldo de Cuenta en Particular");
                Console.WriteLine("4. Consultar saldo de las Cuentas");
                Console.WriteLine("0. Salir");
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Ingresar Número de Cuenta: ");
                        string number = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingresar Monto a Depositar: ");
                        decimal monto = Convert.ToDecimal(Console.ReadLine());
                        Console.Clear();
                        Controller.Controlador.Depositar(number, monto);
                        Run();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Ingresar Número de Cuenta: ");
                        number = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingresar Monto a Retirar: ");
                        monto = Convert.ToDecimal(Console.ReadLine());
                        Console.Clear();
                        Controller.Controlador.Retirar(number, monto);

                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Controlador.ConsultarResumen();

                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Thread.Sleep(500);
                        break;
                    case ConsoleKey.D0:
                        Console.WriteLine("Saliendo del sistema...");
                        option = 0;
                        Thread.Sleep(500);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (option == 0);
            
        }

    }
}
