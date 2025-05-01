namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{

    public string numero { get; }
    public decimal saldo { get; set; }
    public Estado estado { get; set; }
    public decimal tasaDeInteres { get; init; }
    public decimal limiteDeDescubierto { get; set; }
    public string[] titulares { get; set; }
    public TipoCuenta tipo{ get; set; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares, TipoCuenta tipo)
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
