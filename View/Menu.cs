using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("|-----------BIENVENIDO AL SISTEMA DE CUENTAS BANCARIAS-----------| ");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Realizar un Deposito.");
                Console.WriteLine("2. Realizar un Retiro.");
                Console.WriteLine("3. Consultar Resumen de las Cuentas.");
                Console.WriteLine("0. Salir");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("|---------------------REALIZAR DEPÓSITO---------------------|");
                        Console.WriteLine(">Ingresar Número de Cuenta: ");
                        string number = Console.ReadLine();
                        Console.WriteLine(">Ingresar Monto a Depositar: ");
                        decimal monto = Convert.ToDecimal(Console.ReadLine());
                        Console.Clear();
                        Controller.Controlador.Depositar(number, monto);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("|----------------------REALIZAR RETIRO---------------------|");
                        Console.WriteLine(">Ingresar Número de Cuenta: ");
                        number = Console.ReadLine();
                        Console.WriteLine(">Ingresar Monto a Retirar: ");
                        monto = Convert.ToDecimal(Console.ReadLine());
                        Console.Clear();
                        Controller.Controlador.Retirar(number, monto);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("|----------------------RESUMEN DE CUENTAS---------------------|");
                        Controlador.ConsultarResumen();
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.Clear();
                        Console.Write("Saliendo del sistema");
                        for(int i = 0; i < 3; i++)
                        {
                            Console.Write(".");
                            Thread.Sleep(600);
                        }
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (option != 0);   
        }
    }
}
