using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{

    internal class CuentaCorriente : CuentaBancaria
    {
        protected decimal Comision { get; set; }
        public CuentaCorriente(string numero, decimal saldo, string[] titulares,TipoCuenta tipo = TipoCuenta.CuentaCorriente, decimal comision = 0.02m) : base(numero, saldo, titulares, tipo)
        {
            this.Comision = comision;
            this.Tipo = tipo;
        }

        public override bool Depositar(decimal monto, bool flag = false)
        {
            if (Estado == Estado.Inactiva || Estado == Estado.Suspendida)
            {
                throw new CuentaNoActiva(Estado);
            } else if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            else
            {
                monto -= monto * Comision;
                Saldo += monto;
                return flag = true;
            }
                
        }

    }
}
