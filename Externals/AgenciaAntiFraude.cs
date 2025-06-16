using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Externals;

public class AgenciaAntiFraude : IInformarRetiro, IAgenciaAntiFraude
{

    public void EstablecerConexion(string url)
    {

    }
    public void InformarRetiro(string cuentaNumero, decimal monto)
    {
        System.Console.WriteLine($"Agencia Anti Fraude: Retiro de {monto} en la cuenta {cuentaNumero} ha sido informado.");
    }

}
