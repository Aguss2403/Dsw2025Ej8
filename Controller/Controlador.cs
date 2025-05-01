using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Controller
{
    internal static class Controlador
    {
        private static List<CuentaBancaria> cuentas = new List<CuentaBancaria> { };
        public static void Inicializar()
        {
            Domain.Persistencia.Inicializar();
            cuentas.AddRange(Persistencia.GetCuentas());
        }

        public static void Depositar(string number, decimal monto)
        {
            try
            {
                foreach (var cuenta in cuentas)
                {
                    if (cuenta.numero == number)
                    {
                        cuenta.Depositar(monto);
                        return;
                    }
                }
                throw new NumeroDeCuentaNoValido();
            }
            catch(NumeroDeCuentaNoValido ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Retirar(string number, decimal monto)
        {
            try
            {
                foreach (var cuenta in cuentas)
                {
                    if (cuenta.numero == number)
                    {
                        cuenta.Retirar(monto);
                        return;
                    }
                }
                throw new NumeroDeCuentaNoValido();
            }
            catch (NumeroDeCuentaNoValido ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
