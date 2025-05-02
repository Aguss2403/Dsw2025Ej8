using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Data
{
    internal static class Persistencia
    {
        private static List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
        public static void Inicializar()
        {
            cuentas.Add(new CajaDeAhorro("1", 10000, new[] { "Lautaro Sanchez" }) { TasaDeInteres = 0.05m });
            cuentas.Add(new CuentaCorriente("2", 1000, new[] { "Iara Román" }) { LimiteDeDescubierto = 1000 });
            cuentas.Add(new CajaDeAhorro("3", 1000, new[] { "Leandro Villanueva" }) { TasaDeInteres = 0.06m });
            cuentas.Add(new CuentaCorriente("4", 1000, new[] { "Santiago Romano", "Leopoldo Samaniego" }, comision: 0.3m) { LimiteDeDescubierto = 1500 });
        }
        public static List<CuentaBancaria> GetCuentas()
        {
            return cuentas;
        }
    }
}
