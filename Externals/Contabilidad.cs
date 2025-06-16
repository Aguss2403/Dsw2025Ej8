using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Externals
{
    public class Contabilidad : IInformarRetiro
    {
        public void AsentarRetiro(string cuentaNumero, decimal monto) 
        { 

        }
        public void AsentarDeposito(string cuentaNumero, decimal monto) 
        {

        }   
        public void asentarTransferencia(string cuentaOrigen, string cuentaDestino, decimal monto) 
        {

        }

        public void InformarRetiro(string cuentaNumero, decimal monto)
        {
            System.Console.WriteLine($"Contabilidad: Retiro de {monto} en la cuenta {cuentaNumero} ha sido registrado.");
        }
    }
}
