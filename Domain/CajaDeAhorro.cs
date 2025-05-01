using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
       

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares, int tipo = 1) : base(numero, saldo, titulares, tipo)
        {
            this.saldo = saldo;
            this.estado = Estado.Activa;
            this.titulares = titulares;
        }

        public override void Depositar(decimal monto)
        {
            try
            {
                if (monto <= 0)
                {
                    throw new MontoNoValido();
                    
                }
                saldo += monto;
                throw new DepositoExitoso(monto, saldo);
            }
            catch (MontoNoValido ex) { Console.WriteLine(ex.Message); }
            catch (DepositoExitoso ex) { Console.WriteLine(ex.Message); }

        }
    
       
    }
}
