namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{

    public string numero { get; }
    public decimal saldo { get; protected set; }
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

    public virtual bool Depositar(decimal monto, bool flag = false)
    {
        if ( estado == Estado.Activa)
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            saldo += monto;
            return flag = true;
        }
        else
        {
            throw new CuentaInactiva(numero);
        }
    }

    public bool Retirar(decimal monto, bool flag = false)
    {
        if (estado == Estado.Inactiva)
            throw new CuentaInactiva(numero);

        if (monto <= 0)
            throw new MontoNoValido();

        if (monto > saldo + limiteDeDescubierto)
            throw new SaldoInsuficiente();

        saldo -= monto;

        if (saldo <= 0)
        {
            estado = Estado.Suspendida;
            throw new CuentaSuspendida(numero);
        }
        return flag = true;
    }

    public decimal ConsultarSaldo()
    {
        return saldo;
    }

}
