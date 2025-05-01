namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{

    public string numero { get; }
    protected decimal saldo { get; set; }
    protected Estado estado { get; set; }
    protected decimal tasaDeInteres { get; init; }
    protected decimal limiteDeDescubierto { get; set; }
    
    protected string[] titulares { get; set; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares, int tipo)
    {
        this.numero = numero;
        this.saldo = saldo;
        this.estado = Estado.Activa;
        this.titulares = titulares;
    
    }


    public virtual void Depositar(decimal monto)
    {
        try
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            saldo += monto;
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public virtual void Retirar(decimal monto)
    {
        try
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            if (monto > saldo + limiteDeDescubierto)
            {
                throw new SaldoInsuficiente();
            }
            saldo -= monto;
            throw new RetiroExitoso(monto, saldo);
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (SaldoInsuficiente ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (RetiroExitoso ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public decimal ConsultarSaldo()
    {
        return saldo;
    }

}
