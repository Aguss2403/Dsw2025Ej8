using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Externals;


namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuenta = new CuentaBancaria("123456789", 1000.00m, TipoCuenta.CajaDeAhorro, new string[] { "Juan Perez" });
            var agenciaAntiFraude = new AgenciaAntiFraude();
            var agenciaImpositiva = new AgenciaImpositiva();
            var contabilidad = new Contabilidad();

            IInformarRetiro[] IInformarRetiro =
            {
                agenciaAntiFraude,
                agenciaImpositiva,
                contabilidad
            };

            IAgenciaAntiFraude IAgenciaAntiFraude = agenciaAntiFraude;

            cuenta.Retirar(100.00m, IInformarRetiro);
            
            cuenta.Retirar1(2000.00m, IAgenciaAntiFraude);


        }
    }
}
