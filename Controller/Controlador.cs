using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Data;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Controller
{
    internal static class Controlador
    {
        private static List<CuentaBancaria> cuentas = new List<CuentaBancaria> { };
        public static void Inicializar()
        {
            Persistencia.Inicializar();
            cuentas.AddRange(Persistencia.GetCuentas());
        }
        public static void Depositar(string number, decimal monto)
        {
            try
            {
                foreach (var cuenta in cuentas)
                {
                    if (cuenta.Numero == number)
                    {
                        if(cuenta.Depositar(monto))
                        {
                            Console.WriteLine($"El monto de {monto} fue depositado exitosamente en la cuenta {cuenta.Numero}. El saldo actual es: {cuenta.Saldo}");
                            return;
                        }
                    }
                }
                throw new NumeroDeCuentaNoValido();
            }
            catch(NumeroDeCuentaNoValido ex){Console.WriteLine(ex.Message);}
            catch (MontoNoValido ex) { Console.WriteLine(ex.Message); }
            catch (CuentaNoActiva ex) { Console.WriteLine(ex.Message); }
        }
        public static void Retirar(string number, decimal monto)
        {
            try
            {
                foreach (var cuenta in cuentas)
                {
                    if (cuenta.Numero == number)
                    {
                        if(cuenta.Retirar(monto))
                        {
                            Console.WriteLine($"El monto de {monto} fue retirado exitosamente de la cuenta {cuenta.Numero}. El saldo actual es: {cuenta.Saldo}");
                            return;
                        }
                    }
                }
                throw new NumeroDeCuentaNoValido();
            }
            catch (NumeroDeCuentaNoValido ex) { Console.WriteLine(ex.Message); }
            catch (MontoNoValido ex) { Console.WriteLine(ex.Message); }
            catch (SaldoInsuficiente ex) { Console.WriteLine(ex.Message); }
            catch (CuentaSuspendida ex) { Console.WriteLine(ex.Message); }
            catch (CuentaNoActiva ex) { Console.WriteLine(ex.Message); }
        }
        public static void ConsultarResumen()
        {
            
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"{"Número",-15} {"Tipo",-20} {"Estado",-10} {"Saldo",10}");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var cuenta in Persistencia.GetCuentas())
            {
                var resume = new
                {
                    Numero = cuenta.Numero,
                    Titulares = cuenta.Titulares,
                    Saldo = cuenta.Saldo,
                    Tipo = cuenta.Tipo,
                    Estado = cuenta.Estado
                };
                    Console.WriteLine($"{resume.Numero,-15} {resume.Tipo,-20} {resume.Estado,-15} {resume.Saldo,10:C}");
            }
            Console.WriteLine("---------------------------------------------------------------");

        }
    }
}
