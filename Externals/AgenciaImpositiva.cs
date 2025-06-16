using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Externals
{
    public class AgenciaImpositiva : IInformarRetiro
    {

        public void EstablecerConexion(string url)
        {
            // Lógica para establecer conexión con la API de la agencia impositiva
        }

        public void DeclararRetiro(string cuentaNumero, decimal monto)
        {
            // Lógica para declarar un retiro a la agencia impositiva
        }

        public void InformarRetiro(string cuentaNumero, decimal monto)
        {
            System.Console.WriteLine($"Agencia Impositiva: Retiro de {monto} en la cuenta {cuentaNumero} ha sido informado.");
        }
    }
}
