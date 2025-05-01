using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dsw2025Ej8.Domain
{
     public class MontoNoValido : Exception
    {
        public MontoNoValido() : base("El monto no es válido.")
        {
        }
    }
    public class CuentaSuspendida : Exception
    {
        public CuentaSuspendida(string numero) : base($"La cuenta Número: {numero}, ha sido suspendida por saldo negativo o igual a 0.")
        {
        }
    }
    public class CuentaNoActiva : Exception
    {
        public CuentaNoActiva() : base("La cuenta no está activa.")
        {
        }
    }
    public class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente() : base("El saldo es insuficiente para realizar la operación.")
        {
        }
    }
    public class NumeroDeCuentaNoValido : Exception
    {
        public NumeroDeCuentaNoValido() : base("El número de cuenta no es válido.")
        {
        }
    }
    public class CuentaInactiva : Exception
    {
        public CuentaInactiva(string numero) : base($"La cuenta número {numero} está inactiva.")
        {
        }
    }
}

