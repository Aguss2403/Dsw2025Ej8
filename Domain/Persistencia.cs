using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal static class Persistencia
    {
        private static List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
        public static void Inicializar()
        {
            cuentas.Add(new CajaDeAhorro("1", 10000, new[] { "Juan", "Maria" }));
            cuentas.Add(new CuentaCorriente("2", 1000, new[] { "Juan", "Maria" }, comision: 3));
            cuentas.Add(new CajaDeAhorro("3", 1000, new[] { "Juan", "Maria" }));
            cuentas.Add(new CuentaCorriente("4", 1000, new[] { "Juan", "Maria" }, comision: 3));
        }
        public static List<CuentaBancaria> GetCuentas()
        {
            return cuentas;
        }
    }
}
