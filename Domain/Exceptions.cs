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
        public MontoNoValido() : base("El monto ingresado no es válido para la operación solicitada.")
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
        public CuentaNoActiva(Estado estado) : base($"No se puede operar con la cuenta {estado}")
        {
        }
    }
    public class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente() : base("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.")
        {
        }
    }
    public class NumeroDeCuentaNoValido : Exception
    {
        public NumeroDeCuentaNoValido() : base("El número de cuenta no es válido.")
        {
        }
    }
}

