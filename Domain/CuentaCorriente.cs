using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{

    internal class CuentaCorriente : CuentaBancaria
    {
        protected decimal comision { get; set; }
        public CuentaCorriente(string numero, decimal saldo, string[] titulares,TipoCuenta tipo = TipoCuenta.CuentaCorriente, decimal comision = 0.02m) : base(numero, saldo, titulares, tipo)
        {
            this.comision = comision;
            this.tipo = tipo;
        }

        public override bool Depositar(decimal monto, bool flag = false)
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();

            }
            monto -= monto * comision;
            saldo += monto;
            return flag = true;
        }

    }
}
