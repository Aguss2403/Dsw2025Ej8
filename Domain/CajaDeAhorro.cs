using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares, TipoCuenta tipo = TipoCuenta.CajaDeAhorro) : base(numero, saldo, titulares, tipo)
        {
            this.saldo = saldo;
            this.estado = Estado.Activa;
            this.titulares = titulares;
            this.tipo = tipo;
        }
    }
}
